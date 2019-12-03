using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class ComplexType : StructuredType
    {
        public ComplexType(XElement sourceElement, Schema schema) : base(sourceElement, schema)
        {
        }
    }
}
