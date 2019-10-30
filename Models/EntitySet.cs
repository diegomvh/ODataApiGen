using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Od2Ts.Models
{
    public class EntitySet
    {
        public EntitySet(XElement xElement,
        IEnumerable<Action> customActions, IEnumerable<Function> customFunctions)
        {
            EntitySetName = xElement.Attribute("Name")?.Value;
            Name = char.ToUpper(EntitySetName[0]) + EntitySetName.Substring(1);
            EntityType = xElement.Attribute("EntityType")?.Value;
            NameSpace =
                xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
            Actions = customActions.Where(a => a.BindingParameter == EntityType);
            Functions = customFunctions.Where(a => a.BindingParameter == EntityType);
        }

        public string Name { get; private set; }
        public string NameSpace { get; private set; }
        public string EntityType { get; private set; }
        public string EntitySetName { get; private set; }
        public IEnumerable<Action> Actions { get; set; }
        public IEnumerable<Function> Functions { get; set; }
    }
}
