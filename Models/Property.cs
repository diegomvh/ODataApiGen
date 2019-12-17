using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ODataApiGen.Models.Annotations;

namespace ODataApiGen.Models
{
    public class Property
    {
        public Property(XElement element, StructuredType structured)
        {
            Collection = element.Attribute("Type")?.Value.StartsWith("Collection(") ?? false;
            Name = element.Attribute("Name")?.Value;
            MaxLength = element.Attribute("MaxLength")?.Value;
            Nullable = !(element.Attribute("Nullable")?.Value == "false");
            Type = element.Attribute("Type")?.Value.TrimStart("Collection(".ToCharArray()).TrimEnd(')');
            SRID = element.Attribute("SRID")?.Value;

            Annotations = element.Descendants().Where(a => a.Name.LocalName == "Annotation")
                .Select(annot => new Annotation(annot)).ToList();
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsEdmType { get { return !System.String.IsNullOrWhiteSpace(Type) && Type.StartsWith("Edm."); } }
        public bool Collection { get; set; }
        public bool Nullable { get; set; }
        public string MaxLength { get; set; }
        public string DisplayName { get; set; }
        public string SRID { get; set; }
        public List<Annotation> Annotations {get; set;}
    }
    public class PropertyRef
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}
