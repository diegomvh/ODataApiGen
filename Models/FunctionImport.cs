using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class FunctionImport
    {
        public EntityContainer EntityContainer {get; private set;}
        public FunctionImport(XElement xElement, EntityContainer container)
        {
            this.EntityContainer = container;
            EntitySet = xElement.Attribute("EntitySet")?.Value;
            Name = xElement.Attribute("Name")?.Value;
            IncludeInServiceDocument = xElement.Attribute("IncludeInServiceDocument")?.Value == "true";
            var function = xElement.Attribute("Function").Value;
            this.Function = container.Schema.Functions.Where(f => f.FullName == function).FirstOrDefault();
        }

        public string Name { get; private set; }
        public string Namespace => this.EntityContainer.Schema.Namespace; 
        public string FullName => $"{this.Namespace}.{this.Name}";
        public Function Function { get; private set; }
        public string EntitySet { get; private set; }
        public bool IncludeInServiceDocument { get; private set; }
    }
}
