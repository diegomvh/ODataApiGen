using System.Xml.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Models
{
    public class CustomFunction : Callable
    {
        public CustomFunction(XElement xElement) : base(xElement)
        {
        }
    }
}
