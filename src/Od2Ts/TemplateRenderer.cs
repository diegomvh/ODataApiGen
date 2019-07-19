using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Od2Ts.Abstracts;

namespace Od2Ts
{
    public class TemplateRenderer
    {
        private ILogger Logger { get; } = Program.CreateLogger<TemplateRenderer>();
        public string Output { get; private set; }
        public TemplateRenderer(string output)
        {
            this.Output = output;
        }

        private void DoRender(Renderable entity)
        {
            //var ns = entity.Namespace.Replace('.', PathSep);
            var fileName = entity.FileName;
            var directory = entity.Directory;

            File.WriteAllText($"{Output}{Path.DirectorySeparatorChar}{directory}{Path.DirectorySeparatorChar}{fileName}.ts", entity.Render());
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
        public void CreateModels(Angular.Module module)
        {
            foreach (var model in module.Models)
            {
                DoRender(model);
            }
        }
        public void CreateConfig(Angular.Module module, string metadataPath, bool secure, string odataVersion)
        {
            var context = $@"export const {module.EndpointName}Config = {{
  baseUrl: '{metadataPath.TrimEnd("$metadata".ToCharArray())}',
  metadataUrl: '{metadataPath}',
  withCredentials: {secure.ToString().ToLower()},
  creation: new Date('{DateTime.Now.ToString("o")}'),
  version: '{odataVersion}'
}}";
            File.WriteAllText($"{Output}{Path.DirectorySeparatorChar}{module.EndpointName.ToLower()}.config.ts", context);
        }

        public void CreateModule(Angular.Module module)
        {
            DoRender(module);
        }

        public void CreateIndex(Angular.Module module)
        {
            DoRender(module.Index);
        }
    }
}
