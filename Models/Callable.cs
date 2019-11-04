using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Models
{
    public abstract class Callable
    {
        public Callable(XElement xElement)
        {
            Name = xElement.Attribute("Name")?.Value;
            BindingParameter = xElement.Descendants()
                .FirstOrDefault(a => a.Name.LocalName == "Parameter" && a.Attribute("Name").Value == "bindingParameter")?
                .Attribute("Type")?.Value;

            Parameters = xElement.Descendants().Where(a => a.Name.LocalName == "Parameter" && a.Attribute("Name").Value != "bindingParameter")
                .Select(paramElement => new Parameter()
                {
                    Name = paramElement.Attribute("Name")?.Value,
                    IsRequired = paramElement.Attribute("Nullable")?.Value == "false",
                    Type = paramElement.Attribute("Type")?.Value.TrimStart("Collection(".ToCharArray()).TrimEnd(')'),
                    IsCollection = paramElement.Attribute("Type")?.Value.StartsWith("Collection(") ?? false,
                }).ToList();

            ReturnType = xElement.Descendants().SingleOrDefault(a => a.Name.LocalName == "ReturnType")?.Attribute("Type")?.Value;
            if (!string.IsNullOrWhiteSpace(ReturnType) && ReturnType.StartsWith("Collection("))
            {
                ReturnsCollection = true;
                ReturnType = ReturnType.TrimStart("Collection(".ToCharArray()).TrimEnd(')');
            }

            if (!string.IsNullOrWhiteSpace(BindingParameter) && BindingParameter.StartsWith("Collection("))
            {
                IsCollectionAction = true;
                BindingParameter = BindingParameter.TrimStart("Collection(".ToCharArray()).TrimEnd(')');
            }

            NameSpace =
                xElement.Ancestors().First(a => a.Attribute("Namespace") != null)?.Attribute("Namespace")?.Value;
        }
        public string Type { get; protected set; }
        public string Name { get; }
        public string NameSpace { get; }
        public bool IsEdmReturnType { get { return !String.IsNullOrWhiteSpace(ReturnType) && ReturnType.StartsWith("Edm."); } }
        public string ReturnType { get; }
        public string BindingParameter { get; }
        public IEnumerable<Parameter> Parameters { get; }
        public bool IsCollectionAction { get; }
        public bool ReturnsCollection { get; }
    }
}
