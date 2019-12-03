using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class ActionImport
    {
        public EntityContainer EntityContainer {get; private set;}
        public ActionImport(XElement xElement, EntityContainer container)
        {
            this.EntityContainer = container;
            Name = xElement.Attribute("Name")?.Value;
            EntitySet = xElement.Attribute("EntitySet")?.Value;
            var action = xElement.Attribute("Action").Value;
            this.Action = container.Schema.Actions.Where(a => a.FullName == action).FirstOrDefault();
        }

        public string Name { get; private set; }
        public string Namespace => this.EntityContainer.Schema.Namespace; 
        public string FullName => $"{this.Namespace}.{this.Name}";
        public Action Action { get; private set; }
        public string EntitySet { get; private set; }
    }
}
