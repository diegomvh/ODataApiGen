using System.Xml.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Models
{
    public class CustomAction : CustomEventAbstract
    {
        public CustomAction(XElement xElement) : base(xElement)
        {

        }
    }
}
