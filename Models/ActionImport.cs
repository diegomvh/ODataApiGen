using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class ActionImport
    {
        public ActionImport(XElement xElement, List<Action> actions)
        {
            Name = xElement.Attribute("Name")?.Value;
            NameSpace = xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
            EntitySet = xElement.Attribute("EntitySet")?.Value;
            var action = xElement.Attribute("Action").Value;
            this.Action = actions.Where(a => a.FullName == action).FirstOrDefault();
        }

        public string Name { get; private set; }
        public string NameSpace { get; private set; }
        public Action Action { get; private set; }
        public string EntitySet { get; private set; }
    }
}
