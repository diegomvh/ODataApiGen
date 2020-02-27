using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class EntityType : StructuredType {
        public EntityType(XElement element, Schema schema) : base(element, schema)
        {
            Keys = element.Descendants()
                    .Where(a => a.Name.LocalName == "Key")
                    .Descendants()
                    .Select(key => new PropertyRef() {
                        Name = key.Attribute("Name")?.Value,
                        Alias = key.Attribute("Alias")?.Value
                    })
                    .ToList();
            HasStream = element.Attribute("HasStream")?.Value == "true";
            NavigationProperties = element.Descendants().Where(a => a.Name.LocalName == "NavigationProperty")
                .Select(nav => new NavigationProperty(nav, this)).ToList();
        }

        public bool HasStream { get; private set; }
        public bool IsCompositeKey { get { return this.Keys.Count() > 1; } }
        public List<PropertyRef> Keys { get; private set; }
        public List<NavigationProperty> NavigationProperties { get; set; }
    }
}