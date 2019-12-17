using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class NavigationPropertyBinding
    {
        public NavigationPropertyBinding(XElement xElement, EntitySet entitySet)
        {
            Path = xElement.Attribute("Path").Value;
            Target = xElement.Attribute("Target").Value;

        }
        public NavigationPropertyBinding(XElement xElement, Singleton singleton)
        {
            Path = xElement.Attribute("Path").Value;
            Target = xElement.Attribute("Target").Value;

        }
        public string Path { get; set; }
        public string Target { get; set; }
    }
}