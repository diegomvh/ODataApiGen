using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Od2Ts.Interfaces;
using Od2Ts.Models;

namespace Od2Ts.Abstracts
{
    public abstract class TypescriptModelClassAbstract : IHasImports
    {
        public TypescriptModelClassAbstract(XElement sourceElement)
        {
            Name = sourceElement.Attribute("Name")?.Value;
            KeyName =
                sourceElement.Descendants()
                    .Where(a => a.Name.LocalName == "Key")
                    .Descendants()
                    .FirstOrDefault()?  //ToDo: Composite keys
                    .Attribute("Name")?
                    .Value;
            NameSpace = sourceElement.Parent?.Attribute("Namespace")?.Value;

            Properties = sourceElement.Descendants().Where(a => a.Name.LocalName == "Property")
                .Select(propElement => new Property()
                {
                    Name = propElement.Attribute("Name")?.Value,
                    IsRequired = propElement.Attribute("Nullable")?.Value == "false",
                    Type = propElement.Attribute("Type")?.Value.TrimStart("Collection(".ToCharArray()).TrimEnd(')'),
                }).ToList();

            NavigationProperties = sourceElement.Descendants().Where(a => a.Name.LocalName == "NavigationProperty")
                .Select(prop => new NavigationProperty()
                {
                    FullName = prop.Attribute("Name")?.Value,
                    IsCollection = prop.Attribute("Type")?.Value.StartsWith("Collection(") ?? false,
                    Type = prop.Attribute("Type")?.Value.TrimStart("Collection(".ToCharArray()).TrimEnd(')'),
                    ReferentialConstraint = prop.Descendants().SingleOrDefault(a => a.Name.LocalName == "ReferentialConstraint")?.Attribute("Property")?.Value,
                    ReferencedProperty = prop.Descendants().SingleOrDefault(a => a.Name.LocalName == "ReferentialConstraint")?.Attribute("ReferencedProperty")?.Value
                }).ToList();
        }

        public string NameSpace { get; private set; }
        public string Name { get; private set; }
        public string KeyName { get; set; }
        public List<Property> Properties { get; private set; }
        public List<NavigationProperty> NavigationProperties { get; set; }

        public IEnumerable<Import> Imports
        {
            get
            {
                var namespaces = NavigationProperties.Select(a => a.Type).Where(a => a != NameSpace + "." + Name).ToList();
                /*For Not-EDM types (e.g. enums with namespaces, complex types*/
                namespaces.AddRange(Properties.Where(a => !a.Type.StartsWith("Edm.")).Select(a => a.Type));

                var uris = namespaces.Distinct().Select(a => new Import(
                    new Uri("r://" + a.Replace(".", "/"), UriKind.Absolute))
                );
                return uris;
            }
        }

        private Uri _uri;
        public Uri Uri => _uri ?? (_uri = new Uri("r://" + NameSpace.Replace(".", "/") + "/" + Name, UriKind.Absolute));
    }
}
