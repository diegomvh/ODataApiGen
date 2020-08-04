using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public abstract class StructuredType : Annotable
    {
        public Schema Schema {get; private set;}
        public StructuredType(XElement element, Schema schema) : base(element)
        {
            this.Schema = schema;
            Name = element.Attribute("Name")?.Value;
            BaseType = element.Attribute("BaseType")?.Value;
            OpenType = element.Attribute("OpenType")?.Value == "true";

            Properties = element.Descendants().Where(a => a.Name.LocalName == "Property")
                .Select(prop => new Property(prop, this)).ToList();
        }
        public bool IsBaseOf(StructuredType structured)
        {
            return this.IsTypeOf(structured.BaseType);
        }
        public bool IsTypeOf(string type) {
            var names = new List<string>() {$"{this.Schema.Namespace}.{this.Name}"};
            if (!String.IsNullOrEmpty(this.Schema.Alias))
                names.Add($"{this.Schema.Alias}.{this.Name}");
            return names.Contains(type);
        }
        public string Namespace => this.Schema.Namespace;
        public string Name { get; private set; }
        public string BaseType { get; private set; }
        public bool OpenType { get; private set; }
        public string FullName { get { return $"{this.Namespace}.{this.Name}"; } }
        public List<Property> Properties { get; private set; }
    }
}
