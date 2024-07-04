using System.Xml.Linq;
using DotLiquid;

namespace ODataApiGen.Models
{
    public class EntitySet : Annotable, ILiquidizable
    {
        public EntityContainer EntityContainer {get; private set;}
        public EntitySet(XElement element, EntityContainer container) : base(element)
        {
            this.EntityContainer = container;
            Name = element.Attribute("Name")?.Value;
            this.EntityType = element.Attribute("EntityType")?.Value;

            NavigationPropertyBindings = element.Descendants().ToList().Where(a => a.Name.LocalName == "NavigationPropertyBinding")
                .Select(navPropBind => new NavigationPropertyBinding(navPropBind, this));
        }

        public void ImportActions(IEnumerable<ActionImport> actionImports, IEnumerable<Action> actions) {
            Actions = actionImports
                .Where(a => a.EntitySet == Name)
                .Select(ai => actions.FirstOrDefault(a => a.NamespaceQualifiedName == ai.Action))
                .Where(a => a != null);
        }
        public void ImportFunctions(IEnumerable<FunctionImport> functionImports, IEnumerable<Function> functions) {
            Functions = functionImports
                .Where(f => f.EntitySet == Name)
                .Select(fi => functions.FirstOrDefault(f => f.NamespaceQualifiedName == fi.Function))
                .Where(f => f != null);
        }
        public string Name { get; private set; }
        public string Namespace => this.EntityContainer.Namespace; 
        public string Alias => this.EntityContainer.Alias; 
        public string NamespaceQualifiedName => $"{this.Namespace}.{this.Name}";
        public string AliasQualifiedName => $"{this.Alias}.{this.Name}";
        public string EntityType { get; private set; }
        public IEnumerable<Action> Actions { get; set; }
        public IEnumerable<Function> Functions { get; set; }
        public IEnumerable<NavigationPropertyBinding> NavigationPropertyBindings { get; set; }
        public object ToLiquid()
        {
            return new
            {
                this.Name,
                this.NamespaceQualifiedName
            };
        }
    }
}
