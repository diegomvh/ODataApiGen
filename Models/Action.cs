using System.Xml.Linq;

namespace Od2Ts.Models
{
    public class Action : Callable
    {
        public Action(XElement xElement) : base(xElement)
        {
            this.Type = "Action";
        }
    }
}
