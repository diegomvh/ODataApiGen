using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class Parameter
    {
        public Parameter(XElement xElement, Callable callable)
        {
            Name = xElement.Attribute("Name")?.Value;
            Nullable = !(xElement.Attribute("Nullable")?.Value == "false");
            Type = xElement.Attribute("Type")?.Value.TrimStart("Collection(".ToCharArray()).TrimEnd(')');
            IsCollection = xElement.Attribute("Type")?.Value.StartsWith("Collection(") ?? false;
        }
        public string Name { get; set; }
        public bool IsEdmType => !System.String.IsNullOrWhiteSpace(Type) && Type.StartsWith("Edm.");
        public string Type { get; set; }
        public bool Nullable { get; set; }
        public bool IsCollection { get; set; }
    }
}
