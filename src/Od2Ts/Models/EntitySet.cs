using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Od2Ts.Models
{
    public class EntitySet
    {
        public EntitySet(XElement xElement,
        IEnumerable<CustomAction> customActions, IEnumerable<CustomFunction> customFunctions)
        {
            EntitySetName = xElement.Attribute("Name")?.Value;
            Name = char.ToUpper(EntitySetName[0]) + EntitySetName.Substring(1);
            EntityType = xElement.Attribute("EntityType")?.Value;
            NameSpace =
                xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
            CustomActions = customActions.Where(a => a.BindingParameter == EntityType);
            CustomFunctions = customFunctions.Where(a => a.BindingParameter == EntityType);
        }

        public string Name { get; private set; }
        public string NameSpace { get; private set; }
        public string EntityType { get; private set; }
        public string EntitySetName { get; private set; }
        public IEnumerable<CustomAction> CustomActions { get; set; }
        public IEnumerable<CustomFunction> CustomFunctions { get; set; }
    }
}
