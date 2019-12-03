using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class EnumType
    {
        public Schema Schema {get; private set;}
        public string Namespace => this.Schema.Namespace;
        public string Name { get; private set; }
        public string FullName { get { return $"{this.Namespace}.{this.Name}"; } }
        public bool Flags { get; private set; }
        public IEnumerable<EnumMember> Members { get; private set; }
        
        public EnumType(XElement sourceElement, Schema schema)
        {
            this.Schema = schema;
            Name = sourceElement.Attribute("Name")?.Value;
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
