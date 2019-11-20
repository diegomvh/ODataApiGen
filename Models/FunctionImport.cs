using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class FunctionImport
    {
        public FunctionImport(XElement xElement, List<Function> functions)
        {
            EntitySet = xElement.Attribute("EntitySet")?.Value;
            Name = xElement.Attribute("Name")?.Value;
            IncludeInServiceDocument = xElement.Attribute("IncludeInServiceDocument")?.Value == "true";
            NameSpace =
                xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
            var function = xElement.Attribute("Function").Value;
            this.Function = functions.Where(f => f.FullName == function).FirstOrDefault();
        }

        public string Name { get; private set; }
        public string NameSpace { get; private set; }
        public string FullName => $"{this.NameSpace}.{this.Name}";
        public Function Function { get; private set; }
        public string EntitySet { get; private set; }
        public bool IncludeInServiceDocument { get; private set; }
    }
}
