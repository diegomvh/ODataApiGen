using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using DotLiquid;
using ODataApiGen.Models;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class EntityProperty : ILiquidizable
    {
        protected Models.Property Value { get; set; }
        protected Angular.Structured Structured { get; set; }
        public EntityProperty(ODataApiGen.Models.Property prop, Angular.Structured structured)
        {
            this.Structured = structured;
            this.Value = prop;
        }
        public string Name {
            get {
                var required = !(Value is NavigationProperty || Value.Nullable);
                return AngularRenderable.ToTypescriptName(Value.Name, TypeScriptElement.Method) + (!required? "?" : "");
            }
        }

        public string Type => this.Structured.ToTypescriptType(Value.Type) + (Value.IsCollection ? "[]" : "");
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
        public bool IsGeo => this.Value.Type.StartsWith("Edm.Geography") || this.Value.Type.StartsWith("Edm.Geometry");
    }
    public class Entity : Structured 
    {
        public Entity(StructuredType type, ApiOptions options) : base(type, options) {
        }

        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".entity";
        public override string Name => AngularRenderable.ToTypescriptName(this.EdmStructuredType.Name, TypeScriptElement.Class);
        // Exports

        public IEnumerable<Angular.EntityProperty> Properties {
            get {
                var props = this.EdmStructuredType.Properties.ToList();
                if (this.EdmStructuredType is EntityType) 
                    props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
                return props.Select(prop => new Angular.EntityProperty(prop, this));
            }
        } 
        public IEnumerable<Angular.EntityProperty> GeoProperties => this.Properties.Where(p => p.IsGeo);
        public bool HasGeoFields => this.Options.GeoJson && this.GeoProperties.Count() > 0;
        public override object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                EntityType = this.EdmStructuredType.FullName
            };
        }
    }
}