using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ODataApiGen.Models.Annotations;

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
        public List<Annotation> Annotations {get; set;}
        
        public EnumType(XElement element, Schema schema)
        {
            this.Schema = schema;
            Name = element.Attribute("Name")?.Value;
            Flags = element.Attribute("IsFlags")?.Value == "true";
            Members = element.Descendants().Where(a => a.Name.LocalName == "Member")
                .Select(member => new EnumMember(member, this)).ToList();
            Annotations = element.Descendants().Where(a => a.Name.LocalName == "Annotation")
                .Select(annot => new Annotation(annot)).ToList();
        }
    }
}
