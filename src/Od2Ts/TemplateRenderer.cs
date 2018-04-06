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

        public void CreateEntityTypes(IEnumerable<EntityType> types)
        {
            foreach (var entityType in types)
            {
                CreateTypescriptModelType(entityType);
            }
        }

        public void CreateComplexTypes(IEnumerable<ComplexType> types)
        {
            foreach (var complexType in types)
            {
                CreateTypescriptModelType(complexType);
            }
        }

        private void CreateTypescriptModelType(StructuredType entityType)
        {
            DoRender(new Angular.Model(entityType));
        }

        public void CreateEnums(IEnumerable<EnumType> types)
        {
            foreach (var enumType in types)
            {
                CreateEnum(enumType);
            }
        }

        private void CreateEnum(EnumType enumType)
        {
            DoRender(new Angular.Enum(enumType));
        }

        public void CreateServicesForEntitySets(IEnumerable<EntitySet> entitySets)
        {
            foreach (var entitySet in entitySets)
            {
                CreateServiceForEntitySet(entitySet);
            }
        }

        private void CreateServiceForEntitySet(EntitySet entitySet)
        {
            DoRender(new Angular.Service(entitySet));
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

        public void CreateModule(string endpointName, IEnumerable<EntityType> entityTypes, IEnumerable<EntitySet> entitySets)
        {
            DoRender(new Angular.Module(endpointName, entityTypes, entitySets), $"{endpointName.ToLower()}.module");
        }

        public void CreateIndex(string endpointName, IEnumerable<EntityType> entityTypes, IEnumerable<EntitySet> entitySets)
        {
            DoRender(new Angular.Index(endpointName, entityTypes, entitySets), $"index");
        }
    }
}
