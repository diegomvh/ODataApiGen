using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using DotLiquid;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class SchemaField : Dictionary<string, string>, DotLiquid.ILiquidizable {
        public string Name {get; set;}
        public SchemaField(Models.Property property, IEnumerable<PropertyRef> keys, AngularRenderable type) {
            this.Name = property.Name;
            this.Add("type", type == null ? $"'{AngularRenderable.GetType(property.Type)}'" : $"'{type.Type}'");
            var key = keys.FirstOrDefault(k => k.Name == property.Name);
            if (key != null) {
                this.Add("isKey", "true");
                this.Add("ref", $"'{key.Name}'");
                if (!String.IsNullOrWhiteSpace(key.Alias)) {
                    this.Add("name", $"'{key.Alias}'");
                }
            }
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
                Name = this.Name,
                AsField = $"{{{String.Join(", ", this.Select(p => $"{p.Key}: {p.Value}"))}}}"
            };
        }
    }
    public class EntityProperty : ILiquidizable
    {
        private Models.Property Value { get; set; }
        public EntityProperty(Od2Ts.Models.Property prop)
        {
            this.Value = prop;
        }
        public IEnumerable<string> Name { get; set; }

        public string Type => AngularRenderable.GetTypescriptType(Value.Type);
        public object ToLiquid()
        {
            return new
            {
                Name = Value.Name + (Value.IsNullable ? "?" : ""),
                Type = this.Type + (Value.IsCollection ? "[]" : "")
            };
        }
    }
    public class Entity : AngularRenderable, DotLiquid.ILiquidizable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Entity(StructuredType type)
        {
            EdmStructuredType = type;
        }
        public Entity Base { get; private set; }
        public Angular.Service Service {get; private set;}

        public void SetBase(Entity b)
        {
            this.Base = b;
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
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".entity";
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name, this.SchemaName };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public string SchemaName => this.EdmStructuredType.Name + "Schema";

        public IEnumerable<Angular.EntityProperty> Properties => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => new Angular.EntityProperty(prop));

        public IEnumerable<SchemaField> SchemaFields => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => {
                    var type = this.Dependencies.FirstOrDefault(dep => dep.Type == prop.Type);
                    var self = prop.Type == this.Type;
                    return new SchemaField(prop, this.EdmStructuredType.Keys, type as AngularRenderable); 
                    });

        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                SchemaName = this.SchemaName
            };
        }
    }
}