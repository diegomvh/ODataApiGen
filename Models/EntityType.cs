using System.Xml.Linq;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Models
{
    public class EntityType : StructuredType {
        public EntityType(XElement sourceElement, Schema schema) : base(sourceElement, schema)
        {
        }
    }
}