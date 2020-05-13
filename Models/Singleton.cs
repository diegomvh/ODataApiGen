using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class Singleton : Annotable
    {
        public EntityContainer EntityContainer {get; private set;}
        public Singleton(XElement xElement, EntityContainer container) : base(xElement)
        {
            this.EntityContainer = container;
            Name = xElement.Attribute("Name")?.Value;
            Type = xElement.Attribute("Type")?.Value;

            NavigationPropertyBindings = xElement.Descendants().Where(a => a.Name.LocalName == "NavigationPropertyBinding")
                .Select(navPropBind => new NavigationPropertyBinding(navPropBind, this)).ToList();
        }

        public void ImportActions(IEnumerable<ActionImport> actionImports, IEnumerable<Action> actions) {
            Actions = actionImports
                .Where(a => a.EntitySet == Name)
                .Select(ai => actions.FirstOrDefault(a => a.FullName == ai.Action))
                .Union(actions.Where(a => a.IsBound && a.BindingParameter == Type));
        }
        public void ImportFunctions(IEnumerable<FunctionImport> functionImports, IEnumerable<Function> functions) {
            Functions = functionImports
                .Where(f => f.EntitySet == Name)
                .Select(fi => functions.FirstOrDefault(f => f.FullName == fi.Function))
                .Union(functions.Where(f => f.IsBound && f.BindingParameter == Type));
        }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Namespace => this.EntityContainer.Schema.Namespace; 
        public string FullName => $"{this.Namespace}.{this.Name}";
        public IEnumerable<Action> Actions { get; set; }
        public IEnumerable<Function> Functions { get; set; }
        public IEnumerable<NavigationPropertyBinding> NavigationPropertyBindings { get; set; }
    }
}
