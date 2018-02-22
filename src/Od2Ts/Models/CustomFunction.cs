using System.Xml.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Models
{
    public class CustomFunction : CustomEventAbstract
    {
        public CustomFunction(XElement xElement) : base(xElement)
        {
        }
    }
}
