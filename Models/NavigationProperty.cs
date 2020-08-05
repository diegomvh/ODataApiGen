using System;
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
      // Version 2 and 3
      Relationship = xElement.Attribute("Relationship")?.Value;
      ToRole = xElement.Attribute("ToRole")?.Value;
      FromRole = xElement.Attribute("FromRole")?.Value;
    }
    public string FullName { get; set; }
    public string Partner { get; set; }
    public bool ContainsTarget { get; set; }
    public string ReferentialConstraint { get; set; }
    public string ReferencedProperty { get; set; }
    public string Relationship { get; set; }
    public string ToRole { get; set; }
    public string FromRole { get; set; }
    public Association Association { get; set; }
    public string FromEntityType
    {
      get
      {
        return (this.Association != null) ?
            this.Association.Ends.FirstOrDefault(e => e.Role == this.FromRole).Type : 
            String.Empty;
      }
    }
    public string ToEntityType 
    {
      get
      {
        return (this.Association != null) ?
            this.Association.Ends.FirstOrDefault(e => e.Role == this.ToRole).Type : 
            String.Empty;
      }
    }
    public bool Many 
    {
      get
      {
        return (this.Association != null) && this.Association.Ends.FirstOrDefault(e => e.Role == this.ToRole).Multiplicity == "*";
      }
    }
  }
}