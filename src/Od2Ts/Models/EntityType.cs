using System.Xml.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Models
{
    public class EntityType : StructuredType {
        public EntityType(XElement sourceElement) : base(sourceElement)
        {
        }
    }
}