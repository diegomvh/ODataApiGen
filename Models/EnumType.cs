using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class EnumType
    {
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public string Type { get { return $"{this.Namespace}.{this.Name}"; } }
        public bool Flags { get; private set; }
        public IEnumerable<EnumMember> Members { get; private set; }
        
        public EnumType(XElement sourceElement)
        {
            Name = sourceElement.Attribute("Name")?.Value;
            Namespace = sourceElement.Parent?.Attribute("Namespace")?.Value;
            Flags = sourceElement.Attribute("IsFlags")?.Value == "true";
            Members = sourceElement.Descendants().Where(a => a.Name.LocalName == "Member")
                .Select(propElement => new EnumMember()
                {
                    Name = propElement.Attribute("Name")?.Value,
                    Value = propElement.Attribute("Value")?.Value
                }).ToList();
        }
    }
}
