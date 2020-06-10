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
                return Program.Metadata.FindEntityType(this.EntitySet.EntityType);
            }
        }
        public EntityType PropertyType { 
            get {
                var parts = this.Path.Split('/');
                var entity = Program.Metadata.FindEntityType(this.EntitySet.EntityType);
                if (parts.Length > 1) {
                    foreach (var nameOrType in parts.Take(parts.Length - 1)) {
                        var baseEntity = Program.Metadata.FindEntityType(nameOrType);
                        if (baseEntity != null) {
                            entity = baseEntity;
                        } else {
                            entity = entity.FindNavigationProperty(nameOrType).EntityType;
                        }
                    }
                }
                return entity;
            }
        }
        public string PropertyName => this.Path.Split('/').Last();
        public NavigationProperty NavigationProperty { 
            get {
                return this.PropertyType.FindNavigationProperty(this.PropertyName);
            }
        }
    }
}