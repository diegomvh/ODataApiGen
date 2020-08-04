using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class AssociationEnd
    {
        public AssociationEnd(XElement xElement, Association association)
        {
            Type = xElement.Attribute("Type").Value;
            Role = xElement.Attribute("Role").Value;
            Multiplicity = xElement.Attribute("Multiplicity").Value;
        }
        public string Type { get; set; }
        public string Role { get; set; }
        public string Multiplicity { get; set; }
    }
}
