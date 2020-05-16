using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class Property : Annotable
    {
        public StructuredType StructuredType {get; private set;}
        public Property(XElement element, StructuredType structured) : base(element)
        {
            this.StructuredType = structured;
            IsCollection = element.Attribute("Type")?.Value.StartsWith("Collection(") ?? false;
            Name = element.Attribute("Name")?.Value;
            MaxLength = element.Attribute("MaxLength")?.Value;
            Nullable = !(element.Attribute("Nullable")?.Value == "false");
            Type = element.Attribute("Type")?.Value.TrimStart("Collection(".ToCharArray()).TrimEnd(')');
            SRID = element.Attribute("SRID")?.Value;
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsEdmType => !System.String.IsNullOrWhiteSpace(Type) && Type.StartsWith("Edm.");
        public bool IsEnumType => Program.Metadata.EnumTypes.FirstOrDefault(e => e.FullName == this.Type) != null;
        public bool IsComplexType => Program.Metadata.ComplexTypes.FirstOrDefault(e => e.FullName == this.Type) != null;
        public bool IsEntityType => Program.Metadata.EntityTypes.FirstOrDefault(e => e.FullName == this.Type) != null;
        public bool IsCollection { get; set; }
        public bool Nullable { get; set; }
        public string MaxLength { get; set; }
        public string DisplayName { get; set; }
        public string SRID { get; set; }
    }
    public class PropertyRef
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}
