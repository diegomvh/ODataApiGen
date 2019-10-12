using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class SchemaKey : Dictionary<string, string>, DotLiquid.ILiquidizable {
        public SchemaKey(PropertyRef property) {
            this.Add("name", $"'{property.Name}'");
            if (!String.IsNullOrWhiteSpace(property.Alias)) {
                this.Add("name", $"'{property.Alias}'");
                this.Add("resolve", $"(model) => model.{property.Name.Replace('/', '.')}");
            }
        }

        public object ToLiquid()
        {
            return new {
                AsKey = $"{{{String.Join(", ", this.Select(p => $"{p.Key}: {p.Value}"))}}}"
            };
        }
    }

    public class SchemaField : Dictionary<string, string>, DotLiquid.ILiquidizable {
        public SchemaField(Models.Property property, AngularRenderable type) {
            this.Add("name", $"'{property.Name}'");
            this.Add("type", type == null ? $"'{AngularRenderable.GetType(property.Type)}'" : $"'{type.Type}'");
            if (property.IsNullable)
                this.Add("isNullable", "true");
            if (!String.IsNullOrEmpty(property.MaxLength) && property.MaxLength.ToLower() != "max")
                this.Add("maxLength", property.MaxLength);
            if (property.IsCollection)
                this.Add("isCollection", "true");
            if (type is Enum) {
                this.Add("isFlags", (type as Enum).IsFlags);
            } else if (property is NavigationProperty) {
                // Is Navigation
                this.Add("isNavigation", "true");
                var nav = property as NavigationProperty;
                if (!String.IsNullOrEmpty(nav.ReferentialConstraint))
                    this.Add("field", $"'{nav.ReferentialConstraint}'");
                if (!String.IsNullOrEmpty(nav.ReferencedProperty))
                    this.Add("ref", $"'{nav.ReferencedProperty}'");
            }
        }

        public object ToLiquid()
        {
            return new {
                AsField = $"{{{String.Join(", ", this.Select(p => $"{p.Key}: {p.Value}"))}}}"
            };
        }
    }

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
    }
}