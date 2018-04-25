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
        public bool UseInterfaces { get; private set; }
        private char PathSep {get;} = Path.DirectorySeparatorChar;
        public TemplateRenderer(string output, bool useInterfaces)
        {
            this.Output = output;
            this.UseInterfaces = useInterfaces;
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
        public void CreateContext(string metadataPath, string odataVersion)
        {
            var context = $@"export class ODataContext {{
  public MetadataPath = '{metadataPath}';
  public ODataRootPath = '{metadataPath.TrimEnd("$metadata".ToCharArray())}';
  public CreationDate = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}';
  public ODataVersion = '{odataVersion}';
}}";
            File.WriteAllText($"{Output}{PathSep}ODataContext.ts", context);
        }

        public void CreateModule(Angular.Module module)
        {
            DoRender(module, $"{module.EndpointName.ToLower()}.module");
        }

        public void CreateIndex(Angular.Module module)
        {
            DoRender(module, $"index");
        }
    }
}
