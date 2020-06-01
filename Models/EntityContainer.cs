using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace ODataApiGen.Models
{
    public class EntityContainer : Annotable
    {
        private static ILogger Logger {get;} = Program.LoggerFactory.CreateLogger<EntityContainer>();
        public Schema Schema { get; private set; }
        public string Name { get; private set; }
        public string Namespace => this.Schema.Namespace; 
        public string FullName { get { return $"{this.Namespace}.{this.Name}"; } }
        public IEnumerable<EntitySet> EntitySets { get; private set; }
        public IEnumerable<Singleton> Singletons { get; private set; }
        public IEnumerable<FunctionImport> FunctionImports { get; private set; }
        public IEnumerable<ActionImport> ActionImports { get; private set; }
        public IEnumerable<Function> UnboundFunctions {get; private set;}
        public IEnumerable<Action> UnboundActions {get; private set;}

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
        #endregion
        public EntityContainer(XElement element, Schema schema) : base(element)
        {
            this.Schema = schema;
            this.Name = element.Attribute("Name").Value;
            this.EntitySets = EntityContainer.ReadEntitySets(element, this);
            this.Singletons = EntityContainer.ReadSingletons(element, this);
            this.ActionImports = EntityContainer.ReadActionImports(element, this);
            this.FunctionImports = EntityContainer.ReadFunctionImports(element, this);
        }

        public void ResolveActionImports(IEnumerable<Action> actions) {
            this.UnboundActions = actions.Where(f => !f.IsBound);
            foreach (var eset in EntitySets) {
                eset.ImportActions(ActionImports, actions);
            }
            foreach (var single in Singletons) {
                single.ImportActions(ActionImports, actions);
            }
        }

        public void ResolveFunctionImports(IEnumerable<Function> functions) {
            this.UnboundFunctions = functions.Where(f => !f.IsBound);
            foreach (var eset in EntitySets) {
                eset.ImportFunctions(FunctionImports, functions);
            }
            foreach (var single in Singletons) {
                single.ImportFunctions(FunctionImports, functions);
            }
        }
    }
}
