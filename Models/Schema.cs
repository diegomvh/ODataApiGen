using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using ODataApiGen.Models.Annotations;

namespace ODataApiGen.Models
{
    public class Schema 
    {
        private static ILogger Logger {get;} = Program.CreateLogger<Schema>();
        public string Namespace { get; private set; }
        public List<EnumType> EnumTypes { get; private set; }
        public List<ComplexType> ComplexTypes { get; private set; }
        public List<EntityType> EntityTypes { get; private set; }
        public List<Function> Functions { get; private set; }
        public List<Action> Actions { get; private set; }
        public List<EntityContainer> EntityContainers { get; private set; }
        public List<AnnotationList> AnnotationLists { get; private set; }

        #region Static Loaders
        private static List<EnumType> ReadEnums(XElement xdoc, Schema schema)
        {
            Logger.LogDebug("Parsing enums...");
            var enumList = new List<EnumType>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "EnumType");

            foreach (var xElement in elements)
            {
                var enT = new EnumType(xElement, schema);
                enumList.Add(enT);
                Logger.LogInformation($"Enum Type  '{enT.Namespace}.{enT.Name}' parsed");
            }
            return enumList;

        }
        private static List<ComplexType> ReadComplexTypes(XElement xdoc, Schema schema)
        {
            Logger.LogDebug("Parsing entity types...");
            var typeList = new List<ComplexType>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "ComplexType");

            foreach (var xElement in elements)
            {
                var enT = new ComplexType(xElement, schema);
                typeList.Add(enT);
                Logger.LogInformation($"Complex Type '{enT.Namespace}.{enT.Name}' parsed");
            }
            return typeList;
        }
        private static List<EntityType> ReadEntityTypes(XElement xdoc, Schema schema)
        {
            Logger.LogDebug("Parsing entity types...");
            var typeList = new List<EntityType>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "EntityType");

            foreach (var xElement in elements)
            {
                var enT = new EntityType(xElement, schema);
                typeList.Add(enT);
                Logger.LogInformation($"Entity Type '{enT.Namespace}.{enT.Name}' parsed");
            }
            return typeList;
        }

        private static List<Action> ReadActions(XElement xDoc, Schema schema)
        {
            Logger.LogDebug("Parsing actions...");
            List<Action> customActionList = new List<Action>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "Action");
            foreach (var xElement in elements)
            {
                var tCustomAction = new Action(xElement, schema);
                customActionList.Add(tCustomAction);
                Logger.LogInformation($"Action '{tCustomAction.Name}' parsed");
            }
            return customActionList;
        }

        private static List<Function> ReadFunctions(XElement xDoc, Schema schema)
        {
            Logger.LogDebug("Parsing functions...");
            List<Function> customFunctionList = new List<Function>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "Function");
            foreach (var xElement in elements)
            {
                var tCustomFunction = new Function(xElement, schema);
                customFunctionList.Add(tCustomFunction);
                Logger.LogInformation($"Function '{tCustomFunction.Name}' parsed");
            }
            return customFunctionList;
        }
        public static List<EntityContainer> ReadEntityContainer(XElement xDoc, Schema schema)
        {
            Logger.LogDebug("Parsing containers...");
            List<EntityContainer> customFunctionList = new List<EntityContainer>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "EntityContainer");
            foreach (var xElement in elements)
            {
                var tCustomFunction = new EntityContainer(xElement, schema);
                customFunctionList.Add(tCustomFunction);
                Logger.LogInformation($"EntityContainer '{tCustomFunction.Name}' parsed");
            }
            return customFunctionList;
        }

        #endregion
        public Schema(XElement xElement) 
        {
            this.Namespace = xElement.Attribute("Namespace").Value;
            this.EnumTypes = Schema.ReadEnums(xElement, this);
            this.ComplexTypes = Schema.ReadComplexTypes(xElement, this);
            this.EntityTypes = Schema.ReadEntityTypes(xElement, this);
            this.Actions = Schema.ReadActions(xElement, this);
            this.Functions = Schema.ReadFunctions(xElement, this);
            this.EntityContainers = Schema.ReadEntityContainer(xElement, this);
            this.AnnotationLists = xElement.Descendants().Where(a => a.Name.LocalName == "Annotations")
                .Select(element => new AnnotationList(element, this)).ToList();

        }

        public void ResolveFunctions(IEnumerable<Function> functions) {
            foreach (var entityType in EntityTypes) {
                entityType.AddFunctions(functions);
            }
            foreach (var container in EntityContainers) {
                container.ResolveFunctionImports(functions);
            }
        }
        public void ResolveActions(IEnumerable<Action> actions) {
            foreach (var entityType in EntityTypes) {
                entityType.AddActions(actions);
            }
            foreach (var container in EntityContainers) {
                container.ResolveActionImports(actions);
            }
        }
    }
}
