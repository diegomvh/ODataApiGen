using System.Xml.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Models
{
    public class ComplexType : TypescriptModelClassAbstract
    {
        public ComplexType(XElement sourceElement) : base(sourceElement)
        {
        }
    }
}
