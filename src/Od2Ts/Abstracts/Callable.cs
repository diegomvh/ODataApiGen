using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Od2Ts.Interfaces;
using Od2Ts.Models;

namespace Od2Ts.Abstracts
{
    public abstract class Callable
    {
        public Callable(XElement xElement)
        {
            Name = xElement.Attribute("Name")?.Value;
            BindingParameter = xElement.Descendants()
                .Single(a => a.Name.LocalName == "Parameter" && a.Attribute("Name").Value == "bindingParameter")
                .Attribute("Type")?.Value;

            Parameters = xElement.Descendants().Where(a => a.Name.LocalName == "Parameter" && a.Attribute("Name").Value != "bindingParameter")
                .Select(paramElement => new Parameter()
                {
                    Name = paramElement.Attribute("Name")?.Value,
                    IsRequired = paramElement.Attribute("Nullable")?.Value == "false",
                    Type = paramElement.Attribute("Type")?.Value
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
        public string Name { get; }
        public string NameSpace { get; }
        public string ReturnType { get; }
        public string BindingParameter { get; }
        public IEnumerable<Parameter> Parameters { get; }
        public bool IsCollectionAction { get; }
        public bool IsEdmReturnType { get { return !String.IsNullOrWhiteSpace(ReturnType) && ReturnType.StartsWith("Edm."); } }
        public bool ReturnsCollection { get; }
    }
}
