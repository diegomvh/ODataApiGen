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
                return Value.Name + (!required? "?" : "");
            }
        }

        public string Type => this.Structured.ResolveTypescriptType(Value.Type) + (Value.IsCollection ? "[]" : "");
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
    }
    public class Entity : Structured 
    {
        public Entity(StructuredType type, ApiOptions options) : base(type, options) {
        }

        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".entity";
        public override string Name => this.EdmStructuredType.Name.Substring(0, 1).ToUpper() + this.EdmStructuredType.Name.Substring(1);
        // Exports

        public IEnumerable<Angular.EntityProperty> Properties {
            get {
                var props = this.EdmStructuredType.Properties.ToList();
                if (this.EdmStructuredType is EntityType) 
                    props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
                return props.Select(prop => new Angular.EntityProperty(prop, this));
            }
        } 
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