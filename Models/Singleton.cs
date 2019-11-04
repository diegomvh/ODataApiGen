using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class Singleton
    {
        public Singleton(XElement xElement)
        {
            EntitySetName = xElement.Attribute("Name")?.Value;
            Name = char.ToUpper(EntitySetName[0]) + EntitySetName.Substring(1);
            Type = xElement.Attribute("Type")?.Value;
            NameSpace =
                xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
        }

        public string Name { get; private set; }
        public string NameSpace { get; private set; }
        public string Type { get; private set; }
        public string EntitySetName { get; private set; }
    }
}
