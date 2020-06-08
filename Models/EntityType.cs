using System;
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
            Abstract = element.Attribute("Abstract")?.Value == "true";
            HasStream = element.Attribute("HasStream")?.Value == "true";
            NavigationProperties = element.Descendants().Where(a => a.Name.LocalName == "NavigationProperty")
                .Select(nav => new NavigationProperty(nav, this)).ToList();
        }

        public bool Abstract { get; private set; }
        public bool HasStream { get; private set; }
        public bool IsCompositeKey { get { return this.Keys.Count() > 1; } }
        public List<PropertyRef> Keys { get; private set; }
        public List<NavigationProperty> NavigationProperties { get; set; }
        public NavigationProperty FindNavigationProperty(string name) {
            NavigationProperty nav;
            var entity = this;
            while (true) {
                nav = entity.NavigationProperties.FirstOrDefault(n => n.Name == name);
                if (nav != null) return nav;
                if (String.IsNullOrEmpty(entity.BaseType))
                    break;
                entity = Program.Metadata.FindEntityType(entity.BaseType);
            }
            throw new Exception($"'{entity.Name}' has not navigation property for {name}");
        }
    }
}