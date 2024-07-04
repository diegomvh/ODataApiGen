using System.Xml.Linq;
using DotLiquid;

namespace ODataApiGen.Models
{
    public abstract class Callable : ILiquidizable
    {
        public Schema Schema {get; private set;}
        public Callable(XElement xElement, Schema schema)
        {
            this.Schema = schema;
            Name = xElement.Attribute("Name")?.Value;
            IsBound = xElement.Attribute("IsBound")?.Value == "true";
            IsComposable = xElement.Attribute("IsComposable")?.Value == "true";
            EntitySetPath = xElement.Attribute("EntitySetPath")?.Value;

            Parameters = xElement.Descendants().Where(a => a.Name.LocalName == "Parameter")
                .Select(paramElement => new Parameter(paramElement, this)).ToList();

            ReturnType = xElement.Descendants().SingleOrDefault(a => a.Name.LocalName == "ReturnType")?.Attribute("Type")?.Value;
            if (!string.IsNullOrWhiteSpace(ReturnType) && ReturnType.StartsWith("Collection("))
            {
                ReturnsCollection = true;
                ReturnType = ReturnType.Substring(11, ReturnType.Length - 12);
            }

            /*
            BindingParameter = xElement.Descendants()
                .FirstOrDefault(a => a.Name.LocalName == "Parameter" && a.Attribute("Name").Value == "bindingParameter")?
                .Attribute("Type")?.Value;
            if (!string.IsNullOrWhiteSpace(BindingParameter) && BindingParameter.StartsWith("Collection("))
            {
                IsCollection = true;
                BindingParameter = BindingParameter.Substring(11, BindingParameter.Length - 12);
            }
            */
        }
        public string Name { get; }
        public string NamespaceQualifiedName => $"{this.Namespace}.{this.Name}";
        public string AliasQualifiedName => $"{this.Alias}.{this.Name}";
        public string Namespace => this.Schema.Namespace; 
        public string Alias => this.Schema.Alias; 
        public string Type { get; protected set; }
        public string ReturnType { get; }
        public bool IsEdmReturnType => !System.String.IsNullOrWhiteSpace(ReturnType) && ReturnType.StartsWith("Edm.");
        public EnumType EnumReturnType => Program.Metadata.FindEnumType(this.ReturnType);
        public bool IsEnumReturnType => this.EnumReturnType != null;
        public ComplexType ComplexReturnType => Program.Metadata.FindComplexType(this.ReturnType);
        public bool IsComplexReturnType => this.ComplexReturnType != null;
        public EntityType EntityReturnType => Program.Metadata.FindEntityType(this.ReturnType);
        public bool IsEntityReturnType => this.EntityReturnType != null;
        public Parameter BindingParameter => this.Parameters.FirstOrDefault(p => p.Name == "bindingParameter");
        public IEnumerable<Parameter> Parameters { get; }
        public string EntitySetPath { get; }
        public bool IsCollection => this.BindingParameter != null ? this.BindingParameter.IsCollection : false;
        public bool IsBound { get; }
        public bool IsComposable { get; }
        public bool ReturnsCollection { get; }
        public object ToLiquid()
        {
            return new
            {
                this.Name,
                this.NamespaceQualifiedName
            };
        }
    }
}
