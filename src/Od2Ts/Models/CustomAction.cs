using System.Xml.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Models
{
    public class CustomAction : Callable
    {
        public CustomAction(XElement xElement) : base(xElement)
        {
            this.Type = "Action";
        }
    }
}
