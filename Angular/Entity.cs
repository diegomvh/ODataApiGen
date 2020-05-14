using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using DotLiquid;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class EntityProperty : ILiquidizable
    {
        protected Models.Property Value { get; set; }
        public EntityProperty(ODataApiGen.Models.Property prop)
        {
            this.Value = prop;
        }
        public string Name {
            get {
                var required = !(Value is NavigationProperty || Value.Nullable);
                var annot = Value.FindAnnotation<CoreComputedAnnotation>("Org.OData.Core.V1.Computed");
                if (annot != null)
                    required = annot.Bool;
                return Value.Name + (!required? "?" : "");
            }
        }

        public string Type => AngularRenderable.GetTypescriptType(Value.Type) + (Value.IsCollection ? "[]" : "");
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
    }
    public class Entity : Structured 
    {
        public Entity(StructuredType type) : base(type) {
        }

        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".entity";
        public override string Name => this.EdmStructuredType.Name;
        // Exports

        public IEnumerable<Angular.EntityProperty> Properties {
            get {
                var props = this.EdmStructuredType.Properties.ToList();
                if (this.EdmStructuredType is EntityType) 
                    props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
                return props.Select(prop => new Angular.EntityProperty(prop));
            }
        } 
        public override object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                EntityType = this.EntityType
            };
        }
    }
}