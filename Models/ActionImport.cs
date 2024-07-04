﻿using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class ActionImport
    {
        public EntityContainer EntityContainer {get; private set;}
        public ActionImport(XElement xElement, EntityContainer container)
        {
            this.EntityContainer = container;
            this.Name = xElement.Attribute("Name")?.Value;
            this.EntitySet = xElement.Attribute("EntitySet")?.Value;
            this.Action = xElement.Attribute("Action")?.Value;
        }

        public string Name { get; private set; }
        public string Namespace => this.EntityContainer.Namespace; 
        public string NamespaceQualifiedName => $"{this.Namespace}.{this.Name}";
        public string Action { get; private set; }
        public string EntitySet { get; private set; }
    }
}
