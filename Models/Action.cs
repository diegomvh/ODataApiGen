using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class Action : Callable
    {
        public Action(XElement xElement) : base(xElement)
        {
            this.Type = "Action";
        }
    }
}
