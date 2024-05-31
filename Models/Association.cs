using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class Association : Annotable {
        public Schema Schema {get; private set;}
        public Association(XElement element, Schema schema) : base(element)
        {
            this.Schema = schema;
            Name = element.Attribute("Name")?.Value;
            Ends = element.Descendants().Where(a => a.Name.LocalName == "End")
                .Select(end => new AssociationEnd(end, this)).ToList();
        }

        public List<AssociationEnd> Ends { get; private set; }
        public string Namespace => this.Schema.Namespace;
        public string Name { get; private set; }
        public string FullName { get { return $"{this.Namespace}.{this.Name}"; } }
    }
}