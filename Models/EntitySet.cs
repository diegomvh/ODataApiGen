using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class EntitySet
    {
        public EntitySet(XElement xElement, IEnumerable<ActionImport> customActions, IEnumerable<FunctionImport> customFunctions)
        {
            Name = xElement.Attribute("Name")?.Value;
            EntityType = xElement.Attribute("EntityType")?.Value;
            Actions = customActions.Where(a => (a.EntitySet == Name || a.Action.BindingParameter == EntityType)).Select(ai => ai.Action);
            Functions = customFunctions.Where(a => (a.EntitySet == Name || a.Function.BindingParameter == EntityType)).Select(fi => fi.Function);
            NameSpace =
                xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
        }

        public string Name { get; private set; }
        public string NameSpace { get; private set; }
        public string FullName => $"{this.NameSpace}.{this.Name}";
        public string EntityType { get; private set; }
        public IEnumerable<Action> Actions { get; set; }
        public IEnumerable<Function> Functions { get; set; }
    }
}
