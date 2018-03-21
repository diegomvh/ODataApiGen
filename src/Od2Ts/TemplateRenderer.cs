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
        public string EntityTypeTemplate { get; set; }
        public string EntityPropertyTemplate { get; set; }
        public string ImportTemplate { get; set; }
        public string ExportTemplate { get; set; }
        public string EnumTypeTemplate { get; set; }
        public string EnumMemberTemplate { get; set; }
        public string EntitySetServiceTemplate { get; set; }
        public string ContextTemplate { get; set; }
        public string ModuleTemplate { get; set; }
        public string IndexTemplate { get; set; }
        public string CustomActionTemplate { get; set; }
        public string CustomFunctionTemplate { get; set; }
        private char PathSep {get;} = Path.DirectorySeparatorChar;
        public TemplateRenderer(string output, bool useInterfaces)
        {
            this.Output = output;
            this.UseInterfaces = useInterfaces;
        }
        public void LoadTemplates() {
            EntityTypeTemplate = File.ReadAllText(EntityTypeTemplate);
            ImportTemplate = File.ReadAllText(ImportTemplate);
            ExportTemplate = File.ReadAllText(ExportTemplate);
            EnumTypeTemplate = File.ReadAllText(EnumTypeTemplate);
            EnumMemberTemplate = File.ReadAllText(EnumMemberTemplate);
            EntitySetServiceTemplate = File.ReadAllText(EntitySetServiceTemplate);
            ContextTemplate = File.ReadAllText(ContextTemplate);
            ModuleTemplate = File.ReadAllText(ModuleTemplate);
            IndexTemplate = File.ReadAllText(IndexTemplate);
            CustomActionTemplate = File.ReadAllText(CustomActionTemplate);
            CustomFunctionTemplate = File.ReadAllText(CustomFunctionTemplate);
        }
        private string ParseImports(IHasImports entity)
        {
            return string.Join("", entity.GetImportRecords().Select(a =>
                ImportTemplate.Clone().ToString()
                    .Replace("$names$", a.ElementTypeName)
                    .Replace("$relativePaths$", "./" + a.RelativeNamespace)));
        }
       private string ParseExports(IHasImports entity)
        {
            return ExportTemplate.Clone().ToString()
                .Replace("$relativePaths$", 
                "./" + entity.NameSpace.Replace(".", Path.DirectorySeparatorChar.ToString()) + $"{PathSep}{entity.Name}" );
        }

        private void DoRender(IRenderableElement entity, string template, string fileName = null)
        {
            var ns = entity.NameSpace.Replace('.', PathSep);
            if (fileName == null)
                fileName = entity.Name;

            var imports = entity as IHasImports;
            if (imports != null)
            {
                template = template.Replace("$imports$", ParseImports(imports));
            }

            template = template
                .Replace("$entityType$", entity.Name)
                .Replace("$name$", entity.Name)
                .Replace("$nameSpace$", entity.NameSpace);

            File.WriteAllText($"{Output}{PathSep}{ns}{PathSep}{fileName}.ts", template);
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

        private void CreateTypescriptModelType(TypescriptModelClassAbstract entityType)
        {
            var props = entityType.Properties.Select(prop =>
                prop.AsField());

            var refs = entityType.NavigationProperties.Select(nav =>
                nav.AsField());

            var template = EntityTypeTemplate.Clone().ToString()
                .Replace("$type$", UseInterfaces ? "interface" : "class")
                .Replace("$properties$", string.Join("", props))
                .Replace("$navigationProperties$", string.Join("", refs));

            DoRender(entityType, template);
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
            var members = enumType.Members.Select(m => EnumMemberTemplate.Clone().ToString()
                .Replace("$memberName$", m.Name)
                .Replace("$memberValue$", m.Value));

            var template = EnumTypeTemplate.Clone().ToString()
                .Replace("$members$", string.Join("", members).TrimEnd(','));
            DoRender(enumType, template);
        }


        public void CreateServicesForEntitySets(IEnumerable<EntitySet> entitySets)
        {
            foreach (var entitySet in entitySets)
            {
                CreateServiceForEntitySet(entitySet);
            }
        }

        private string GetCustomActionsTemplate(List<CustomAction> actions)
        {
            if (!actions.Any())
            {
                return string.Empty;
            }
            var result = "\r\n\t/*Custom Actions*/\r\n";
            foreach (var customAction in actions)
            {
                var returnTypeName = customAction.ReturnTypescriptType;
                var returnType = returnTypeName + (customAction.ReturnsCollection ? "[]" : "");
                var baseExecFunctionName = customAction.IsCollectionAction
                    ? "CustomCollectionAction"
                    : "CustomAction";

                var parameters = customAction.Parameters;
                var argumentWithType = new List<string>();
                var boundArgument = customAction.IsCollectionAction ? "" : customAction.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)) + "Id";

                if (!customAction.IsCollectionAction)
                    argumentWithType.Add($"{boundArgument}: any");

                argumentWithType.AddRange(parameters.Select(p => 
                    p.AsDefinition()
                ));

                result += CustomActionTemplate.Clone().ToString()
                    .Replace("$actionName$", customAction.Name)
                    .Replace("$actionFullName$", customAction.NameSpace + "." + customAction.Name)
                    .Replace("$returnType$", returnType)
                    .Replace("$bound$", String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $", {boundArgument}")
                    .Replace("$execName$", baseExecFunctionName)
                    .Replace("$argument$", parameters.Any()? ", { " + String.Join(", ", parameters.Select(p => p.Name)) + " }" : "")
                    .Replace("$argumentWithType$", String.Join(", ", argumentWithType))
                    .Replace("$returnPromise$", customAction.IsEdmReturnType ? 
                        $".then(resp => resp.toPropertyValue<{returnTypeName}>())" : 
                    customAction.ReturnsCollection ? 
                        $".then(resp => resp.toEntitySet<{returnTypeName}>().getEntities())" : 
                        $".then(resp => resp.toEntity<{returnTypeName}>())");
            }
            return result;
        }

        private string GetCustomFunctionsTemplate(List<CustomFunction> functions)
        {
            if (!functions.Any())
            {
                return string.Empty;
            }
            var result = "\r\n\t/*Custom Functions*/\r\n";
            foreach (var customFunction in functions)
            {
                var returnTypeName = customFunction.ReturnTypescriptType;
                var returnType = returnTypeName + (customFunction.ReturnsCollection ? "[]" : "");
                var baseExecFunctionName = customFunction.IsCollectionAction
                    ? "CustomCollectionFunction"
                    : "CustomFunction";

                var parameters = customFunction.Parameters;
                var argumentWithType = new List<string>();
                var boundArgument = customFunction.IsCollectionAction ? "" : customFunction.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)) + "Id";

                if (!customFunction.IsCollectionAction)
                    argumentWithType.Add($"{boundArgument}: any");

                argumentWithType.AddRange(parameters.Select(p => 
                    p.AsDefinition()
                ));

                result += CustomFunctionTemplate.Clone().ToString()
                    .Replace("$functionName$", customFunction.Name)
                    .Replace("$functionFullName$", customFunction.NameSpace + "." + customFunction.Name)
                    .Replace("$returnType$", returnType)
                    .Replace("$bound$", String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $", {boundArgument}")
                    .Replace("$execName$", baseExecFunctionName)
                    .Replace("$argument$", parameters.Any()? ", { " + String.Join(", ", parameters.Select(p => p.Name)) + " }" : "")
                    .Replace("$argumentWithType$", String.Join(", ", argumentWithType))
                    .Replace("$returnPromise$", customFunction.IsEdmReturnType ? 
                        $".then(resp => resp.toPropertyValue<{returnTypeName}>())" : 
                    customFunction.ReturnsCollection ? 
                        $".then(resp => resp.toEntitySet<{returnTypeName}>().getEntities())" : 
                        $".then(resp => resp.toEntity<{returnTypeName}>())");
            }
            return result;
        }

        private void CreateServiceForEntitySet(EntitySet entitySet)
        {
            var entityTypeName = entitySet.EntityType.Split('.').Last();
            var template = EntitySetServiceTemplate.Clone().ToString()
                .Replace("$entitySetName$", entitySet.Name)
                .Replace("$entitySetUrl$", entitySet.EntitySetName)
                .Replace("$entityTypeName$", entityTypeName)
                .Replace("$customActions$", GetCustomActionsTemplate(entitySet.CustomActions.ToList()))
                .Replace("$customFunctions$", GetCustomFunctionsTemplate(entitySet.CustomFunctions.ToList()));
            DoRender(entitySet, template);
        }

        public void CreateContext(string metadataPath, string odataVersion)
        {

            var template = ContextTemplate.Clone().ToString()
                .Replace("$odataRootPath$", metadataPath.TrimEnd("$metadata".ToCharArray()))
                .Replace("$metadataPath$", metadataPath)
                .Replace("$CreationDate$", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("$ODataVersion$", odataVersion);
            File.WriteAllText($"{Output}{PathSep}ODataContext.ts", template);
        }

        public void CreateModule(Module module)
        {
            var template = ModuleTemplate.Clone().ToString()
                .Replace("$moduleProviders$", string.Join(",\r\n\t", module.EntitySets.Select(a => a.Name)))
                .Replace("$moduleName$", module.Name);

            DoRender(module, template, $"{module.Name.ToLower()}.module");
        }

        public void CreateIndex(Module module) 
        {
            var template = IndexTemplate.Clone().ToString()
                .Replace("$exportTypes$", string.Join("", module.EntityTypes.Distinct().Select(e => ParseExports(e))))
                .Replace("$exportServices$", string.Join("", module.EntitySets.Distinct().Select(e => ParseExports(e))))
                .Replace("$moduleName$", $"{module.Name.ToLower()}.module");

            File.WriteAllText($"{Output}{PathSep}index.ts", template);
        }
    }
}
