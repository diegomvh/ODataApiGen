using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

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

        #region Static Loaders
        private static List<EnumType> ReadEnums(XElement xdoc)
        {
            Logger.LogDebug("Parsing enums...");
            var enumList = new List<EnumType>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "EnumType");

            foreach (var xElement in elements)
            {
                var enT = new EnumType(xElement);
                enumList.Add(enT);
                Logger.LogInformation($"Enum Type  '{enT.NameSpace}.{enT.Name}' parsed");
            }
            return enumList;

        }
        private static List<ComplexType> ReadComplexTypes(XElement xdoc)
        {
            Logger.LogDebug("Parsing entity types...");
            var typeList = new List<ComplexType>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "ComplexType");

            foreach (var xElement in elements)
            {
                var enT = new ComplexType(xElement);
                typeList.Add(enT);
                Logger.LogInformation($"Complex Type '{enT.NameSpace}.{enT.Name}' parsed");
            }
            return typeList;
        }
        private static List<EntityType> ReadEntityTypes(XElement xdoc)
        {
            Logger.LogDebug("Parsing entity types...");
            var typeList = new List<EntityType>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "EntityType");

            foreach (var xElement in elements)
            {
                var enT = new EntityType(xElement);
                typeList.Add(enT);
                Logger.LogInformation($"Entity Type '{enT.NameSpace}.{enT.Name}' parsed");
            }
            return typeList;
        }

        private static List<Action> ReadActions(XElement xDoc)
        {
            Logger.LogDebug("Parsing actions...");
            List<Action> customActionList = new List<Action>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "Action");
            foreach (var xElement in elements)
            {
                var tCustomAction = new Action(xElement);
                customActionList.Add(tCustomAction);
                Logger.LogInformation($"Action '{tCustomAction.Name}' parsed");
            }
            return customActionList;
        }

        private static List<Function> ReadFunctions(XElement xDoc)
        {
            Logger.LogDebug("Parsing functions...");
            List<Function> customFunctionList = new List<Function>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "Function");
            foreach (var xElement in elements)
            {
                var tCustomFunction = new Function(xElement);
                customFunctionList.Add(tCustomFunction);
                Logger.LogInformation($"Function '{tCustomFunction.Name}' parsed");
            }
            return customFunctionList;
        }
        public static List<Schema> ReadSchemas(XElement xdoc)
        {
            Logger.LogDebug("Parsing entity types...");
            var schemas = new List<Schema>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "Schema");

            foreach (var xElement in elements)
            {
                var enT = new Schema(xElement);
                schemas.Add(enT);
                Logger.LogInformation($"Schema Type '{enT.Namespace}' parsed");
            }
            return schemas;
        }
        #endregion
        private Schema(XElement xElement) 
        {
            this.Namespace = xElement.Attribute("Namespace").Value;
            this.EnumTypes = Schema.ReadEnums(xElement);
            this.ComplexTypes = Schema.ReadComplexTypes(xElement);
            this.EntityTypes = Schema.ReadEntityTypes(xElement);
            this.EntityTypes = Schema.ReadEntityTypes(xElement);
            this.Actions = Schema.ReadActions(xElement);
            this.Functions = Schema.ReadFunctions(xElement);
            this.EntityContainers = EntityContainer.ReadEntityContainer(xElement, this);
        }
    }
}
