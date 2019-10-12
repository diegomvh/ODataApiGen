using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class EntitySchemaField : SchemaField
    {
        public EntitySchemaField(Property property, AngularRenderable type, bool self = false) : base(property, type)
        {
            if (type is Enum) {
                this.Add("enum", type.Name);
            } else if (type != null || self) {
                this.Add("schema", self ? "'self'" : AngularRenderable.GetTypescriptType(property.Type) + "Schema");
            }
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
    public class ModelInterface : Model, DotLiquid.ILiquidizable
    {
        public ModelInterface(StructuredType type) : base(type)
        {
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".entity";
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name, this.SchemaName };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public string SchemaName => this.EdmStructuredType.Name + "Schema";

        public IEnumerable<Angular.EntityProperty> Properties => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => new Angular.EntityProperty(prop));

        public IEnumerable<SchemaKey> SchemaKeys => this.EdmStructuredType.Keys.Select(prop => new SchemaKey(prop));
        public IEnumerable<EntitySchemaField> SchemaFields => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => {
                    var type = this.Dependencies.FirstOrDefault(dep => dep.Type == prop.Type);
                    var self = prop.Type == this.Type;
                    return new EntitySchemaField(prop, type as AngularRenderable, self); 
                    });

        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                SchemaName = this.SchemaName
            };
        }
    }
}