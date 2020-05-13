using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class NavigationProperty : Property
    {
        public NavigationProperty(XElement xElement, StructuredType structured) : base(xElement, structured)
        {
            Name = xElement.Attribute("Name")?.Value.Split(".").Last();
            FullName = xElement.Attribute("Name")?.Value;
            MaxLength = null;
            IsCollection = xElement.Attribute("Type")?.Value.StartsWith("Collection(") ?? false;
            ContainsTarget = xElement.Attribute("ContainsTarget")?.Value == "true";
            Partner = xElement.Attribute("Partner")?.Value;
            Type = xElement.Attribute("Type")?.Value.TrimStart("Collection(".ToCharArray()).TrimEnd(')');
            ReferentialConstraint = xElement.Descendants().SingleOrDefault(a => a.Name.LocalName == "ReferentialConstraint")?.Attribute("Property")?.Value;
            ReferencedProperty = xElement.Descendants().SingleOrDefault(a => a.Name.LocalName == "ReferentialConstraint")?.Attribute("ReferencedProperty")?.Value;
        }
        public string FullName { get; set; }
        public string Partner { get; set; }
        public bool ContainsTarget {get; set;}
        public string ReferentialConstraint { get; set; }
        public string ReferencedProperty { get; set; }
    }
}