using System.Xml.Linq;
using DotLiquid;

namespace ODataApiGen.Models
{
    public abstract class StructuredType : Annotable, ILiquidizable
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
            if (this.IsTypeOf(structured.BaseType)) return true;
            var baseType = Program.Metadata.FindEntityType(structured.BaseType);
            if (baseType != default)
                return this.IsBaseOf(baseType);
            return false;
        }
        public bool IsTypeOf(string type) {
            var names = new List<string>() {$"{this.Schema.Namespace}.{this.Name}"};
            if (!String.IsNullOrEmpty(this.Schema.Alias))
                names.Add($"{this.Schema.Alias}.{this.Name}");
            return names.Contains(type);
        }
        public int HierarchyLevelOf(StructuredType structured, int level = 0)
        {
            if (this.IsTypeOf(structured.BaseType)) return level;
            var baseType = Program.Metadata.FindEntityType(structured.BaseType);
            if (baseType != default)
                return this.HierarchyLevelOf(baseType, level + 1);
            return level;
        }
        public string Namespace => this.Schema.Namespace;
        public string Alias => this.Schema.Alias;
        public string Name { get; private set; }
        public string BaseType { get; private set; }
        public bool OpenType { get; private set; }
        public string NamespaceQualifiedName => $"{this.Namespace}.{this.Name}";
        public string AliasQualifiedName => $"{this.Alias}.{this.Name}";
        public List<Property> Properties { get; private set; }
        public object ToLiquid()
        {
            return new
            {
                this.Name,
                this.NamespaceQualifiedName,
                this.AliasQualifiedName,
            };
        }
    }
}
