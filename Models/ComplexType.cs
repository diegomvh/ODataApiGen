using System.Xml.Linq;

namespace Od2Ts.Models
{
    public class ComplexType : StructuredType
    {
        public ComplexType(XElement sourceElement) : base(sourceElement)
        {
        }
    }
}
