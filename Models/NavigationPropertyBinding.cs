using System;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class NavigationPropertyBinding
    {
        public EntitySet EntitySet {get; private set;}
        public Singleton Singleton {get; private set;}
        public NavigationPropertyBinding(XElement xElement, EntitySet entitySet)
        {
            this.EntitySet = entitySet;
            Path = xElement.Attribute("Path").Value;
            Target = xElement.Attribute("Target").Value;
        }
        public NavigationPropertyBinding(XElement xElement, Singleton singleton)
        {
            this.Singleton = singleton;
            Path = xElement.Attribute("Path").Value;
            Target = xElement.Attribute("Target").Value;
        }
        public string Path { get; set; }
        public string Target { get; set; }
        public EntityType EntityType { 
            get {
                var entityType = this.EntitySet.EntityType;
                return Program.Metadata.EntityTypes.FirstOrDefault(e => e.FullName == entityType);
            }
        }
        public NavigationProperty NavigationProperty { 
            get {
                var name = this.Path.Split('/').Last();
                var entityType = this.EntityType;
                NavigationProperty prop = null;
                while (true) {
                    prop = entityType.NavigationProperties.FirstOrDefault(nav => nav.Name == name);
                    if (prop != null) break;
                    if (String.IsNullOrEmpty(entityType.BaseType))
                        throw new Exception($"No navigation property for: {name}");
                    entityType = Program.Metadata.EntityTypes.FirstOrDefault(e => e.FullName == entityType.BaseType);
                }
                return prop;
            }
        }
    }
}