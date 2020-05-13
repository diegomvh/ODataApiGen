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
                var parts = this.Path.Split('/');
                var entityType = (parts.Length > 1)? parts.First() : this.EntitySet.EntityType;
                return this.EntitySet.EntityContainer.Schema.EntityTypes.FirstOrDefault(e => e.FullName == entityType);
            }
        }
        public NavigationProperty NavigationProperty { 
            get {
                var prop = this.Path.Split('/').Last();
                return this.EntityType.NavigationProperties.FirstOrDefault(nav => nav.Name == prop);
            }
        }
    }
}