using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class EntitySet
    {
        public EntityContainer EntityContainer {get; private set;}
        public EntitySet(XElement xElement, EntityContainer container)
        {
            this.EntityContainer = container;
            Name = xElement.Attribute("Name")?.Value;
            EntityType = xElement.Attribute("EntityType")?.Value;

            NavigationPropertyBindings = xElement.Descendants().Where(a => a.Name.LocalName == "NavigationPropertyBinding")
                .Select(navPropBind => new NavigationPropertyBinding()
                {
                    Path = navPropBind.Attribute("Path").Value,
                    Target = navPropBind.Attribute("Target").Value,
                }).ToList();
        }

        public void AddActions(IEnumerable<ActionImport> actionImports, IEnumerable<Action> actions) {
            Actions = actionImports
                .Where(a => a.EntitySet == Name)
                .Select(ai => actions.FirstOrDefault(a => a.FullName == ai.Action))
                .Union(actions.Where(a => a.IsBound && a.BindingParameter == EntityType));
        }
        public void AddFunctions(IEnumerable<FunctionImport> functionImports, IEnumerable<Function> functions) {
            Functions = functionImports
                .Where(f => f.EntitySet == Name)
                .Select(fi => functions.FirstOrDefault(f => f.FullName == fi.Function))
                .Union(functions.Where(f => f.IsBound && f.BindingParameter == EntityType));
        }
        public string Name { get; private set; }
        public string Namespace => this.EntityContainer.Schema.Namespace; 
        public string FullName => $"{this.Namespace}.{this.Name}";
        public string EntityType { get; private set; }
        public IEnumerable<Action> Actions { get; set; }
        public IEnumerable<Function> Functions { get; set; }
        public IEnumerable<NavigationPropertyBinding> NavigationPropertyBindings { get; set; }
    }
}
