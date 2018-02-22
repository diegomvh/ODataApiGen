using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Od2Ts.Interfaces;

namespace Od2Ts.Models
{
    public class EnumType : IRenderableElement
    {

        public string Name { get; private set; }

        public string NameSpace { get; private set; }
        public IEnumerable<EnumMember> Members { get; private set; }

        public EnumType(XElement sourceElement)
        {
            Name = sourceElement.Attribute("Name")?.Value;
            NameSpace = sourceElement.Parent?.Attribute("Namespace")?.Value;
            Members = sourceElement.Descendants().Where(a => a.Name.LocalName == "Member")
                .Select(propElement => new EnumMember()
                {
                    Name = propElement.Attribute("Name")?.Value,
                    Value = propElement.Attribute("Value")?.Value
                }).ToList();
        }
    }
}
