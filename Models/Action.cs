using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class Action : Callable
    {
        public Action(XElement xElement, Schema schema) : base(xElement, schema)
        {
            this.Type = "Action";
        }
    }
}
