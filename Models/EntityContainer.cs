using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace ODataApiGen.Models
{
    public class EntityContainer 
    {
        private static ILogger Logger {get;} = Program.CreateLogger<EntityContainer>();
        public Schema Schema { get; private set; }
        public string Name { get; private set; }
        public List<EntitySet> EntitySets { get; private set; }
        public List<Singleton> Singletons { get; private set; }
        public List<FunctionImport> FunctionImports { get; private set; }
        public List<ActionImport> ActionImports { get; private set; }

        #region Static Loaders
        private static List<EntitySet> ReadEntitySets(XElement xDoc, EntityContainer container)
        {
            Logger.LogDebug("Parsing entity sets...");
            var entitySetList = new List<EntitySet>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "EntitySet");

            foreach (var xElement in elements)
            {
                var tContainer = new EntitySet(xElement, container);
                entitySetList.Add(tContainer);
                Logger.LogInformation($"Entity set '{tContainer.Name}' parsed");
            }

            return entitySetList;
        }

        private static List<Singleton> ReadSingletons(XElement xDoc, EntityContainer container)
        {
            Logger.LogDebug("Parsing singletons...");
            List<Singleton> singletonList = new List<Singleton>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "Singleton");
            foreach (var xElement in elements)
            {
                var tSingleton = new Singleton(xElement, container);
                singletonList.Add(tSingleton);
                Logger.LogInformation($"Singleton '{tSingleton.Name}' parsed");
            }
            return singletonList;
        }
        private static List<FunctionImport> ReadFunctionImports(XElement xDoc, EntityContainer container)
        {
            Logger.LogDebug("Parsing function imports...");
            List<FunctionImport> functionImportList = new List<FunctionImport>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "FunctionImport");
            foreach (var xElement in elements)
            {
                var tFuncionImport = new FunctionImport(xElement, container);
                functionImportList.Add(tFuncionImport);
                Logger.LogInformation($"FunctionImport '{tFuncionImport.Name}' parsed");
            }
            return functionImportList;
        }
        private static List<ActionImport> ReadActionImports(XElement xDoc, EntityContainer container)
        {
            Logger.LogDebug("Parsing actions imports...");
            List<ActionImport> actionImportList = new List<ActionImport>();
            var elements = xDoc.Descendants().Where(a => a.Name.LocalName == "ActionImport");
            foreach (var xElement in elements)
            {
                var tActionImport = new ActionImport(xElement, container);
                actionImportList.Add(tActionImport);
                Logger.LogInformation($"ActionImport '{tActionImport.Name}' parsed");
            }
            return actionImportList;
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
        private EntityContainer(XElement xElement, Schema schema) 
        {
            this.Schema = schema;
            this.Name = xElement.Attribute("Name").Value;
            this.EntitySets = EntityContainer.ReadEntitySets(xElement, this);
            this.Singletons = EntityContainer.ReadSingletons(xElement, this);
            this.ActionImports = EntityContainer.ReadActionImports(xElement, this);
            this.FunctionImports = EntityContainer.ReadFunctionImports(xElement, this);

            foreach (var eset in EntitySets) {
                eset.AddActions(ActionImports, schema.Actions);
                eset.AddFunctions(FunctionImports, schema.Functions);
            }

            foreach (var single in Singletons) {
                single.AddActions(ActionImports, schema.Actions);
                single.AddFunctions(FunctionImports, schema.Functions);
            }
        }
    }
}
