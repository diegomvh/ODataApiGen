using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class EnumMember
    {
        public EnumType EnumType {get; private set;}
        public EnumMember(XElement xElement, EnumType enumm)
        {
            this.EnumType = enumm;
            Name = xElement.Attribute("Name")?.Value;
            Value = xElement.Attribute("Value")?.Value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
