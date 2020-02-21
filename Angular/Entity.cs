using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using DotLiquid;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class EntityProperty : StructuredProperty
    {
        public EntityProperty(ODataApiGen.Models.Property prop) : base(prop) { }
        public override string Name {
            get {
                var required = !(Value is NavigationProperty || Value.Nullable);
                var annot = Value.Annotation("Org.OData.Core.V1.Computed");
                if (annot != null)
                    required = annot.Bool.ToLower() != "true";
                return Value.Name + (!required? "?" : "");
            }
        }
        public override string Type => AngularRenderable.GetTypescriptType(Value.Type) + (Value.Collection ? "[]" : "");
    }
    public class Entity : Structured 
    {
        public Angular.Schema Schema { get; private set; }
        public Entity(StructuredType type, Angular.Schema schema) : base(type) {
            this.Schema = schema;
            this.Dependencies.Add(schema);
        }

        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".entity";
        public override string Name => this.EdmStructuredType.Name;
        // Exports

        public override IEnumerable<Angular.StructuredProperty> Properties => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => new Angular.EntityProperty(prop));
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