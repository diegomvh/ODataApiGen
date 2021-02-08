using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public abstract class Callable
    {
        public Schema Schema {get; private set;}
        public Callable(XElement xElement, Schema schema)
        {
            this.Schema = schema;
            Name = xElement.Attribute("Name")?.Value;
            IsBound = xElement.Attribute("IsBound")?.Value == "true";
            IsComposable = xElement.Attribute("IsComposable")?.Value == "true";
            EntitySetPath = xElement.Attribute("EntitySetPath")?.Value;

            Parameters = xElement.Descendants().Where(a => a.Name.LocalName == "Parameter")
                .Select(paramElement => new Parameter(paramElement, this)).ToList();

            ReturnType = xElement.Descendants().SingleOrDefault(a => a.Name.LocalName == "ReturnType")?.Attribute("Type")?.Value;
            if (!string.IsNullOrWhiteSpace(ReturnType) && ReturnType.StartsWith("Collection("))
            {
                ReturnsCollection = true;
                ReturnType = ReturnType.Substring(11, ReturnType.Length - 12);
            }

            /*
            BindingParameter = xElement.Descendants()
                .FirstOrDefault(a => a.Name.LocalName == "Parameter" && a.Attribute("Name").Value == "bindingParameter")?
                .Attribute("Type")?.Value;
            if (!string.IsNullOrWhiteSpace(BindingParameter) && BindingParameter.StartsWith("Collection("))
            {
                IsCollection = true;
                BindingParameter = BindingParameter.Substring(11, BindingParameter.Length - 12);
            }
            */
        }
        public string Name { get; }
        public string Namespace => this.Schema.Namespace; 
        public string FullName => $"{this.Namespace}.{this.Name}";
        public string Type { get; protected set; }
        public bool IsEdmReturnType { get { return !String.IsNullOrWhiteSpace(ReturnType) && ReturnType.StartsWith("Edm."); } }
        public string ReturnType { get; }
        public Parameter BindingParameter => this.Parameters.FirstOrDefault(p => p.Name == "bindingParameter");
        public IEnumerable<Parameter> Parameters { get; }
        public string EntitySetPath { get; }
        public bool IsCollection => this.BindingParameter != null ? this.BindingParameter.IsCollection : false;
        public bool IsBound { get; }
        public bool IsComposable { get; }
        public bool ReturnsCollection { get; }
    }
}
