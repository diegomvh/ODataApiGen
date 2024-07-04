﻿using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class FunctionImport
    {
        public EntityContainer EntityContainer {get; private set;}
        public FunctionImport(XElement xElement, EntityContainer container)
        {
            this.EntityContainer = container;
            this.EntitySet = xElement.Attribute("EntitySet")?.Value;
            this.Name = xElement.Attribute("Name")?.Value;
            this.IncludeInServiceDocument = xElement.Attribute("IncludeInServiceDocument")?.Value == "true";
            this.Function = xElement.Attribute("Function")?.Value;
        }

        public string Name { get; private set; }
        public string Namespace => this.EntityContainer.Namespace; 
        public string NamespaceQualifiedName => $"{this.Namespace}.{this.Name}";
        public string Function { get; private set; }
        public string EntitySet { get; private set; }
        public bool IncludeInServiceDocument { get; private set; }
    }
}
