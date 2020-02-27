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
        public string Namespace => this.Schema.Namespace;
        public string Name { get; private set; }
        public string BaseType { get; private set; }
        public bool OpenType { get; private set; }
        public string FullName { get { return $"{this.Namespace}.{this.Name}"; } }
        public List<Property> Properties { get; private set; }
        public void AddActions(IEnumerable<Action> actions) {
            Actions = actions.Where(a => a.IsBound && a.BindingParameter == FullName);
        }
        public void AddFunctions(IEnumerable<Function> functions) {
            Functions = functions.Where(f => f.IsBound && f.BindingParameter == FullName);
        }
        public IEnumerable<Action> Actions { get; set; } = Enumerable.Empty<Action>();
        public IEnumerable<Function> Functions { get; set; } = Enumerable.Empty<Function>();
    }
}
