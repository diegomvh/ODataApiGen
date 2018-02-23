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
        public string EntityTypeTemplate { get; set; }
        public string EntityPropertyTemplate { get; set; }
        public string ImportsTemplate { get; set; }
        public string EnumTypeTemplate { get; set; }
        public string EnumMemberTemplate { get; set; }
        public string EntitySetServiceTemplate { get; set; }
        public string ContextTemplate { get; set; }
        public string ModuleTemplate { get; set; }
        public string CustomActionTemplate { get; set; }
        public string CustomFunctionTemplate { get; set; }
        private char PathSep {get;} = Path.DirectorySeparatorChar;

        public TemplateRenderer(string output)
        {
            this.Output = output;
        }
        public void LoadTemplates() {
            EntityTypeTemplate = File.ReadAllText(EntityTypeTemplate);
            EntityPropertyTemplate = File.ReadAllText(EntityPropertyTemplate);
            ImportsTemplate = File.ReadAllText(ImportsTemplate);
            EnumTypeTemplate = File.ReadAllText(EnumTypeTemplate);
            EnumMemberTemplate = File.ReadAllText(EnumMemberTemplate);
            EntitySetServiceTemplate = File.ReadAllText(EntitySetServiceTemplate);
            ContextTemplate = File.ReadAllText(ContextTemplate);
            ModuleTemplate = File.ReadAllText(ModuleTemplate);
            CustomActionTemplate = File.ReadAllText(CustomActionTemplate);
            CustomFunctionTemplate = File.ReadAllText(CustomFunctionTemplate);
        }

        private string ParseImports(IHasImports entity)
        {
            return string.Join("", entity.GetImportRecords().Select(a =>
                ImportsTemplate.Clone().ToString()
                    .Replace("$moduleNames$", a.ElementTypeName)
                    .Replace("$relativePaths$", "./" + a.RelativeNamespace)));
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
                .Replace("$EntityType$", entity.Name)
                .Replace("$Name$", entity.Name)
                .Replace("$NameSpace$", entity.NameSpace);

            File.WriteAllText($"{Output}{PathSep}{ns}{PathSep}{fileName}.ts", template);
        }

        public void CreateEntityTypes(IEnumerable<EntityType> types)
        {
            foreach (var entityType in types)
            {
                CreateTypescriptModelClass(entityType);
            }
        }

        public void CreateComplexTypes(IEnumerable<ComplexType> types)
        {
            foreach (var complexType in types)
            {
                CreateTypescriptModelClass(complexType);
            }
        }

        private void CreateTypescriptModelClass(TypescriptModelClassAbstract entityType)
        {
            var props = entityType.Properties.Select(prop =>
                EntityPropertyTemplate.Clone()
                    .ToString()
                    .Replace("$propertyName$", prop.TypescriptName)
                    .Replace("$propertyType$", prop.TypescriptType));


            var refs = entityType.NavigationProperties.Select(nav =>
                EntityPropertyTemplate.Clone()
                    .ToString()
                    .Replace("$propertyName$", nav.Name)
                    .Replace("$propertyType$", nav.Type.Split('.').Last() + (nav.IsCollection ? "[]" : ""))
            );

            var template = EntityTypeTemplate.Clone().ToString()
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
                var returnTypeName = !string.IsNullOrWhiteSpace(customAction.ReturnType) ? customAction.ReturnType.Split('.').Last(a => !string.IsNullOrWhiteSpace(a))
                    + (customAction.ReturnsCollection ? "[]" : "") : "any";
                var baseExecFunctionName = customAction.IsCollectionAction
                    ? "ExecCustomCollectionAction"
                    : "ExecCustomAction";

                var entityArgument = customAction.IsCollectionAction ? "" : customAction.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)) + "Id";
                var argumentWithType = customAction.IsCollectionAction ? "" : $"{entityArgument}: any";

                var parameters = customAction.Parameters;
                if (parameters.Count() > 0) {
                    entityArgument += (String.IsNullOrEmpty(entityArgument)? "" : ", ") + String.Join(", ", parameters.Select(p => p.Name));
                    argumentWithType += (String.IsNullOrEmpty(argumentWithType) ? "" : ", ") + String.Join(", ", parameters.Select(p => $"{p.TypescriptName}: {p.TypescriptType}"));
                }

                result += CustomActionTemplate.Clone().ToString()
                    .Replace("$actionName$", customAction.Name)
                    .Replace("$actionFullName$", customAction.NameSpace + "." + customAction.Name)
                    .Replace("$returnType$", returnTypeName)
                    .Replace("$execName$", baseExecFunctionName)
                    .Replace("$argument$", ", " + entityArgument)
                    .Replace("$argumentWithType$", argumentWithType);
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
                var returnTypeName = customFunction.ReturnType.Split('.').Last(a => !string.IsNullOrWhiteSpace(a))
                    + (customFunction.ReturnsCollection ? "[]" : "");
                var baseExecFunctionName = customFunction.IsCollectionAction
                    ? "ExecCustomCollectionFunction"
                    : "ExecCustomFunction";

                var entityArgument = customFunction.IsCollectionAction ? "" : customFunction.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)) + "Id";
                var argumentWithType = customFunction.IsCollectionAction ? "" : $"{entityArgument}: any";

                var parameters = customFunction.Parameters;
                if (parameters.Count() > 0) {
                    entityArgument += (String.IsNullOrEmpty(entityArgument)? "" : ", ") + String.Join(", ", parameters.Select(p => p.Name));
                    argumentWithType += (String.IsNullOrEmpty(argumentWithType) ? "" : ", ") + String.Join(", ", parameters.Select(p => $"{p.TypescriptName}: {p.TypescriptType}"));
                }

                result += CustomFunctionTemplate.Clone().ToString()
                    .Replace("$functionName$", customFunction.Name)
                    .Replace("$functionFullName$", customFunction.NameSpace + "." + customFunction.Name)
                    .Replace("$returnType$", returnTypeName)
                    .Replace("$execName$", baseExecFunctionName)
                    .Replace("$argument$", ", " + entityArgument)
                    .Replace("$argumentWithType$", argumentWithType);
            }
            return result;
        }

        private void CreateServiceForEntitySet(EntitySet entitySet)
        {
            var template = EntitySetServiceTemplate.Clone().ToString()
                .Replace("$entitySetUrl$", entitySet.EntitySetName)
                .Replace("$entityTypeName$", entitySet.EntityType.Split('.').Last())
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

        public void CreateAngularModule(AngularModule module)
        {
            var template = ModuleTemplate.Clone().ToString()
                .Replace("$moduleProviders$", string.Join(",\r\n\t", module.EntitySets.Select(a => a.Name)))
                .Replace("$moduleName$", module.Name);

            DoRender(module, template);

        }
    }
}
