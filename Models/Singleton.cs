using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class Singleton
    {
        public Singleton(XElement xElement, IEnumerable<ActionImport> customActions, IEnumerable<FunctionImport> customFunctions)
        {
            Name = xElement.Attribute("Name")?.Value;
            Type = xElement.Attribute("Type")?.Value;
            Actions = customActions
                .Where(a => (a.EntitySet == Name || a.Action.BindingParameter == Type))
                .Select(ai => ai.Action);
            Functions = customFunctions
                .Where(a => (a.EntitySet == Name || a.Function.BindingParameter == Type))
                .Select(fi => fi.Function);
            NameSpace =
                xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
        }

        public string Name { get; private set; }
        public string Type { get; private set; }
        public string FullName => $"{this.NameSpace}.{this.Name}";
        public IEnumerable<Action> Actions { get; set; }
        public IEnumerable<Function> Functions { get; set; }
        public string NameSpace { get; private set; }
    }
}
