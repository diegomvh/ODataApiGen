using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public abstract class Model : AngularRenderable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Model Base { get; private set; }
        public Angular.Collection Collection {get; private set;}
        public Angular.Service Service {get; private set;}
        public Model(StructuredType type)
        {
            EdmStructuredType = type;
        }

        public void SetBase(Model b)
        {
            this.Base = b;
        }
        public void SetCollection(Collection collection)
        {
            this.Collection = collection;
        }
        public void SetService(Service service)
        {
            this.Service = service;
        }

        // Imports
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var types = this.EdmStructuredType.NavigationProperties
                    .Select(a => a.Type)
                    .ToList();
                /*For Not-EDM types (e.g. enums with namespaces, complex types*/
                types.AddRange(this.EdmStructuredType.Properties
                    .Where(a => !a.IsEdmType)
                    .Select(a => a.Type));
                if (this.Base != null)
                    types.Add(this.Base.EdmStructuredType.Type);
                return types.Distinct();
            }
        }
        public override string Name => this.EdmStructuredType.Name;
        public override string NameSpace => this.EdmStructuredType.NameSpace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public string GetFieldType(string type)
        {
            if (String.IsNullOrWhiteSpace(type))
                return "any";
            switch (type)
            {
                case "Edm.String":
                case "Edm.Duration":
                case "Edm.Guid":
                case "Edm.Binary":
                    return "string";
                case "Edm.Int16":
                case "Edm.Int32":
                case "Edm.Int64":
                case "Edm.Double":
                case "Edm.Decimal":
                case "Edm.Single":
                case "Edm.Byte":
                    return "number";
                case "Edm.Boolean":
                    return "boolean";
                case "Edm.DateTimeOffset":
                    return "Date";
                default:
                    {
                        return type.Contains(".") && !type.StartsWith("Edm") ? type : "Object";
                    }
            }
        }
        public string RenderKey(PropertyRef propertyRef)
        {
            var d = new Dictionary<string, string>() {
                {"name", $"'{propertyRef.Name}'"}
            };
            if (!String.IsNullOrWhiteSpace(propertyRef.Alias)) {
                d.Add("name", $"'{propertyRef.Alias}'");
                d.Add("resolve", $"(model) => model.{propertyRef.Name.Replace('/', '.')}");
            }
            return $"{{{String.Join(", ", d.Select(p => $"{p.Key}: {p.Value}"))}}}";
        }
        public string RenderField(Models.Property property)
        {
            var d = new Dictionary<string, string>() {
                {"name", $"'{property.Name}'"}
            };
            var propType = property.Type;
            if (property.IsCollection)
                propType = $"{propType}Collection";
            var type = this.Dependencies.FirstOrDefault(dep => dep.Type == propType);
            d.Add("type", type == null ? $"'{this.GetFieldType(property.Type)}'" : $"'{type.Type}'");
            if (property.IsNullable)
                d.Add("isNullable", "true");
            if (!String.IsNullOrEmpty(property.MaxLength) && property.MaxLength.ToLower() != "max")
                d.Add("maxLength", property.MaxLength);
            if (property.IsCollection)
                d.Add("isCollection", "true");
            if (type is Enum) {
                d.Add("isFlags", (type as Enum).IsFlags);
            } else if (property is NavigationProperty) {
                // Is Navigation
                d.Add("isNavigation", "true");
                var nav = property as NavigationProperty;
                if (!String.IsNullOrEmpty(nav.ReferentialConstraint))
                    d.Add("field", $"'{nav.ReferentialConstraint}'");
                if (!String.IsNullOrEmpty(nav.ReferencedProperty))
                    d.Add("ref", $"'{nav.ReferencedProperty}'");
            }
            return $"{{{String.Join(", ", d.Select(p => $"{p.Key}: {p.Value}"))}}}";
        }
    }
}