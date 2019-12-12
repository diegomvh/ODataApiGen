using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using DotLiquid;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class SchemaField : Dictionary<string, string>, DotLiquid.ILiquidizable {
        public string Name {get; set;}
        public SchemaField(Models.Property property, IEnumerable<PropertyRef> keys, AngularRenderable type) {
            this.Name = property.Name;
            this.Add("type", $"'{AngularRenderable.GetType(property.Type)}'");
            var key = keys.FirstOrDefault(k => k.Name == property.Name);
            if (key != null) {
                this.Add("key", "true");
                this.Add("ref", $"'{key.Name}'");
                if (!String.IsNullOrWhiteSpace(key.Alias)) {
                    this.Add("name", $"'{key.Alias}'");
                }
            }
            if (!(property is NavigationProperty) && !property.Nullable)
                this.Add("nullable", "false");
            if (!String.IsNullOrEmpty(property.MaxLength) && property.MaxLength.ToLower() != "max")
                this.Add("maxLength", property.MaxLength);
            if (!String.IsNullOrEmpty(property.SRID))
                this.Add("srid", property.SRID);
            if (property.Collection)
                this.Add("collection", "true");
            if (type is Enum) {
                this.Add("flags", (type as Enum).Flags.ToString().ToLower());
            } else if (property is NavigationProperty) {
                // Is Navigation
                this.Add("navigation", "true");
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
    public abstract class EntityProperty : ILiquidizable
    {
        protected Models.Property Value { get; set; }
        public EntityProperty(ODataApiGen.Models.Property prop)
        {
            this.Value = prop;
        }
        public abstract string Name { get; }

        public abstract string Type {get;}
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
    }
    public abstract class Entity : AngularRenderable, DotLiquid.ILiquidizable
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
                types.AddRange(this.EdmStructuredType.Actions.Select(a => a.Type));
                types.AddRange(this.EdmStructuredType.Functions.Select(a => a.Type));
                if (this.Base != null)
                    types.Add(this.Base.EdmStructuredType.FullName);
                return types.Distinct();
            }
        }
        public override string Name => this.EdmStructuredType.Name;
        public string EntityType => this.EdmStructuredType.FullName;
        public override string NameSpace => this.EdmStructuredType.Namespace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name, this.SchemaName };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public string SchemaName => this.EdmStructuredType.Name + "Schema";

        public abstract IEnumerable<Angular.EntityProperty> Properties {get;} 

        public IEnumerable<SchemaField> SchemaFields => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => {
                    var type = this.Dependencies.FirstOrDefault(dep => dep.Type == prop.Type);
                    return new SchemaField(prop, this.EdmStructuredType.Keys, type as AngularRenderable); 
                    });

        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                EntityType = this.EntityType,
                SchemaName = this.SchemaName
            };
        }
    }
}