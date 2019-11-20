using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using ODataApiGen.Models;

namespace ODataApiGen
{
    public class MetadataReader
    {
        private ILogger Logger {get;} = Program.CreateLogger<MetadataReader>();
        public List<EntityType> EntityTypes { get; private set; }
        public List<ComplexType> ComplexTypes { get; private set; }
        public List<EnumType> EnumTypes { get; private set; }
        public List<EntitySet> EntitySets { get; private set; }
        public List<Singleton> Singletons { get; private set; }
        public List<FunctionImport> FunctionImports { get; private set; }
        public List<ActionImport> ActionImports { get; private set; }
        public List<Action> Actions { get; private set; }
        public List<Function> Functions { get; private set; }


        private void ReadEntityTypes(XDocument xdoc)
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
            EntityTypes = typeList;
        }

        private void ReadComplexTypes(XDocument xdoc)
        {
            Logger.LogDebug("Parsing entity types...");
            var typeList = new List<ComplexType>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "ComplexType");

            foreach (var xElement in elements)
            {
                var enT = new ComplexType(xElement);
                typeList.Add(enT);
                Logger.LogInformation($"Entity Type '{enT.NameSpace}.{enT.Name}' parsed");
            }
            ComplexTypes = typeList;
        }

        private void ReadEnums(XDocument xdoc)
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
            EnumTypes = enumList;

        }

        private void ReadEntitySets(XDocument xdoc, List<ActionImport> actions, List<FunctionImport> functions)
        {
            Logger.LogDebug("Parsing entity sets...");
            var entitySetList = new List<EntitySet>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "EntitySet");

            foreach (var xElement in elements)
            {
                var tContainer = new EntitySet(xElement, actions, functions);
                entitySetList.Add(tContainer);
                Logger.LogInformation($"Entity set '{tContainer.Name}' parsed");
            }

            EntitySets = entitySetList;
        }

        private void ReadActions(XDocument xDoc)
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
            Actions = customActionList;
        }

        private void ReadFunctions(XDocument xDoc)
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
            Functions = customFunctionList;
        }

        private void ReadSingletons(XDocument xDoc, List<ActionImport> actions, List<FunctionImport> functions)
        {
            Logger.LogDebug("Parsing singletons...");
            List<Singleton> singletonList = new List<Singleton>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "Singleton");
            foreach (var xElement in elements)
            {
                var tSingleton = new Singleton(xElement, actions, functions);
                singletonList.Add(tSingleton);
                Logger.LogInformation($"Singleton '{tSingleton.Name}' parsed");
            }
            Singletons = singletonList;
        }

        private void ReadFunctionImports(XDocument xDoc, List<Function> functions)
        {
            Logger.LogDebug("Parsing function imports...");
            List<FunctionImport> functionImportList = new List<FunctionImport>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "FunctionImport");
            foreach (var xElement in elements)
            {
                var tFuncionImport = new FunctionImport(xElement, functions);
                functionImportList.Add(tFuncionImport);
                Logger.LogInformation($"FunctionImport '{tFuncionImport.Name}' parsed");
            }
            FunctionImports = functionImportList;
        }
        private void ReadActionImports(XDocument xDoc, List<Action> actions)
        {
            Logger.LogDebug("Parsing actions imports...");
            List<ActionImport> actionImportList = new List<ActionImport>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "ActionImport");
            foreach (var xElement in elements)
            {
                var tActionImport = new ActionImport(xElement, actions);
                actionImportList.Add(tActionImport);
                Logger.LogInformation($"ActionImport '{tActionImport.Name}' parsed");
            }
            ActionImports = actionImportList;
        }

        public MetadataReader(XDocument xdoc)
        {
            ReadEntityTypes(xdoc);
            ReadComplexTypes(xdoc);
            ReadEnums(xdoc);

            ReadActions(xdoc);
            ReadFunctions(xdoc);
            ReadActionImports(xdoc, Actions);
            ReadFunctionImports(xdoc, Functions);

            ReadEntitySets(xdoc, ActionImports, FunctionImports);
            ReadSingletons(xdoc, ActionImports, FunctionImports);
        }
    }
}
