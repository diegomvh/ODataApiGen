using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Od2Ts.Abstracts;
using Od2Ts.Extensions;
using Od2Ts.Interfaces;
using Od2Ts.Models;

namespace Od2Ts
{
    public class TemplateRenderer
    {
        private ILogger Logger { get; } = Program.CreateLogger<TemplateRenderer>();
        public string Output { get; private set; }
        private char PathSep {get;} = Path.DirectorySeparatorChar;
        public TemplateRenderer(string output)
        {
            this.Output = output;
        }

        private void DoRender(Renderable entity, string fileName = null)
        {
            var ns = entity.NameSpace.Replace('.', PathSep);
            if (fileName == null)
                fileName = entity.Name;

            File.WriteAllText($"{Output}{PathSep}{ns}{PathSep}{fileName}.ts", entity.Render());
        }

        public void CreateModels(Angular.Module module)
        {
            foreach (var model in module.Models)
            {
                DoRender(model);
            }
        }
        public void CreateEnums(Angular.Module module)
        {
            foreach (var enumm in module.Enums)
            {
                DoRender(enumm);
            }
        }
        public void CreateServices(Angular.Module module)
        {
            foreach (var service in module.Services)
            {
                DoRender(service);
            }
        }
        public void CreateContext(Angular.Module module, string metadataPath, bool secure, string odataVersion)
        {
            var context = $@"import {{ ODataContext }} from 'angular-odata';

export class {module.EndpointName}Context extends ODataContext {{
  public baseUrl = '{metadataPath.TrimEnd("$metadata".ToCharArray())}';
  public metadataUrl = '{metadataPath}';
  public withCredentials = {secure.ToString().ToLower()};
  public creation = new Date('{DateTime.Now.ToString("o")}');
  public version = '{odataVersion}';
}}";
            File.WriteAllText($"{Output}{PathSep}{module.EndpointName}Context.ts", context);
        }

        public void CreateModule(Angular.Module module)
        {
            DoRender(module, $"{module.EndpointName.ToLower()}.module");
        }

        public void CreateIndex(Angular.Module module)
        {
            DoRender(module.Index, $"index");
        }
    }
}
