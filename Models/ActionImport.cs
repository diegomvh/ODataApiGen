using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Od2Ts.Models
{
    public class ActionImport
    {
        public ActionImport(XElement xElement)
        {
            EntitySetName = xElement.Attribute("EntitySet")?.Value;
            Name = xElement.Attribute("Name")?.Value;
            Action = xElement.Attribute("Action")?.Value;
            NameSpace =
                xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
        }

        public string Name { get; private set; }
        public string NameSpace { get; private set; }
        public string Action { get; private set; }
        public string EntitySetName { get; private set; }
    }
}
