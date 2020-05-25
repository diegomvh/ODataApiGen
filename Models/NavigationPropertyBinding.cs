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
                return Program.Metadata.EntityTypes.FirstOrDefault(e => e.FullName == this.EntitySet.EntityType);
            }
        }
        public EntityType PropertyType {
            get {
                var parts = this.Path.Split('/');
                var entityType = parts.Length == 2 ? parts[0] : String.Empty;
                return Program.Metadata.EntityTypes.FirstOrDefault(e => e.FullName == entityType);
            }
        } 
        public string PropertyName => this.Path.Split('/').Last();
        public NavigationProperty NavigationProperty { 
            get {
                var name = this.PropertyName;
                var entity = (this.PropertyType != null)? this.PropertyType : this.EntityType; 
                while (true) {
                    var prop = entity.NavigationProperties.FirstOrDefault(nav => nav.Name == name);
                    if (prop != null) return prop;
                    if (String.IsNullOrEmpty(entity.BaseType))
                        break;
                    entity = Program.Metadata.EntityTypes.FirstOrDefault(e => e.FullName == entity.BaseType);
                }
                throw new Exception($"No navigation property for: {name}");
            }
        }
    }
}