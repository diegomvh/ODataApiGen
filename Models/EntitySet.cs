using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ODataApiGen.Models.Annotations;

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
                .Select(navPropBind => new NavigationPropertyBinding(navPropBind, this)).ToList();

            Annotations = xElement.Descendants().Where(a => a.Name.LocalName == "Annotation")
                .Select(element => new Annotation(element)).ToList();
        }

        public void ImportActions(IEnumerable<ActionImport> actionImports, IEnumerable<Action> actions) {
            Actions = actionImports
                .Where(a => a.EntitySet == Name)
                .Select(ai => actions.FirstOrDefault(a => a.FullName == ai.Action));
        }
        public void ImportFunctions(IEnumerable<FunctionImport> functionImports, IEnumerable<Function> functions) {
            Functions = functionImports
                .Where(f => f.EntitySet == Name)
                .Select(fi => functions.FirstOrDefault(f => f.FullName == fi.Function));
        }
        public string Name { get; private set; }
        public string Namespace => this.EntityContainer.Namespace; 
        public string FullName => $"{this.Namespace}.{this.Name}";
        public string EntityType { get; private set; }
        public IEnumerable<Action> Actions { get; set; }
        public IEnumerable<Function> Functions { get; set; }
        public IEnumerable<NavigationPropertyBinding> NavigationPropertyBindings { get; set; }
        public List<Annotation> Annotations {get; set;}
    }
}
