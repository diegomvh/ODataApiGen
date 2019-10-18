using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Od2Ts.Models
{
    public class FunctionImport
    {
        public FunctionImport(XElement xElement)
        {
            EntitySetName = xElement.Attribute("EntitySet")?.Value;
            Name = xElement.Attribute("Name")?.Value;
            Function = xElement.Attribute("Function")?.Value;
            NameSpace =
                xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
        }

        public string Name { get; private set; }
        public string NameSpace { get; private set; }
        public string Function { get; private set; }
        public string EntitySetName { get; private set; }
    }
}
