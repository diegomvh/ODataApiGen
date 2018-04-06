using System;
using System.Xml.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Models
{
    public class ComplexType : StructuredType
    {
        public ComplexType(XElement sourceElement) : base(sourceElement)
        {
        }
    }
}
