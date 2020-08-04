using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class AssociationSet : Annotable
    {
        public EntityContainer EntityContainer {get; private set;}
        public AssociationSet(XElement element, EntityContainer container) : base(element)
        {
            this.EntityContainer = container;
            Name = element.Attribute("Name")?.Value;
            this.Association = element.Attribute("Association")?.Value;

            AssociationSetEnds = element.Descendants().ToList().Where(a => a.Name.LocalName == "End")
                .Select(end => new AssociationSetEnd(end, this));
        }

        public string Name { get; private set; }
        public string Namespace => this.EntityContainer.Namespace; 
        public string FullName => $"{this.Namespace}.{this.Name}";
        public string Association { get; private set; }
        public IEnumerable<AssociationSetEnd> AssociationSetEnds { get; set; }
    }
}
