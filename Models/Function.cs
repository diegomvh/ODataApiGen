using System.Xml.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Models
{
    public class Function : Callable
    {
        public Function(XElement xElement) : base(xElement)
        {
            this.Type = "Function";
        }
    }
}
