using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;
using DotLiquid;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class ModelProperty : ILiquidizable
    {
        protected Models.Property Value { get; set; }
        protected Angular.Structured Structured { get; set; }
        public ModelProperty(ODataApiGen.Models.Property prop, Angular.Structured structured)
        {
            this.Value = prop;
            this.Structured = structured;
        }
        public string Name {
            get {
                var required = !(Value is NavigationProperty || Value.Nullable);
                return Value.Name + (!required? "?" : "");
            }
        }

        public string Type { get {
            var type = this.Structured.ToTypescript(Value.Type);
            if (this.Value.IsEnumType)
                return type;
            if (Value.IsCollection)
                return type + (Value.IsEdmType ? "[]" : $"Collection<{type}, {type}Model<{type}>>");
            else 
                return type + (Value.IsEdmType ? "" : $"Model<{type}>");
        }}
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
        public bool IsGeo => this.Value.Type.StartsWith("Edm.Geography") || this.Value.Type.StartsWith("Edm.Geometry");
    }
    public class Model : Structured 
    {
        public Angular.Entity Entity { get; private set; }

        public Model(StructuredType type, Angular.Entity entity, ApiOptions options) : base(type, options) {
            this.Entity = entity;
        }
        public Angular.Collection Collection {get; private set;}

        public void SetCollection(Collection collection)
        {
            this.Collection = collection;
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override string Name => this.EdmStructuredType.Name.Substring(0, 1).ToUpper() + this.EdmStructuredType.Name.Substring(1) + "Model";
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var list = new List<string> {
                    this.EdmStructuredType.FullName
                };
                list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
                list.AddRange(this.EdmStructuredType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmStructuredType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                if (this.EdmStructuredType is EntityType)
                    list.AddRange((this.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
                return list;
            }
        }
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

        public IEnumerable<Angular.ModelProperty> Properties {
            get {
                var props = this.EdmStructuredType.Properties.ToList();
                if (this.EdmStructuredType is EntityType) 
                    props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
                return props.Select(prop => new Angular.ModelProperty(prop, this));
            }
        } 
        public IEnumerable<string> Actions {
            get {
                var modelActions = this.EdmStructuredType.Actions.Where(a => !a.IsCollection);
                return modelActions.Count() > 0 ? this.RenderCallables(modelActions, useset: true) : Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Functions {
            get {
                var modelFunctions = this.EdmStructuredType.Functions.Where(a => !a.IsCollection);
                return modelFunctions.Count() > 0 ? this.RenderCallables(modelFunctions, useset: true) : Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Navigations {
            get {
                var service = Program.Metadata.EntitySets.FirstOrDefault(s => this.EdmStructuredType.IsTypeOf(s.EntityType));
                if (service != null) {
                    var bindings = service.NavigationPropertyBindings.Where(binding => !binding.NavigationProperty.IsCollection);
                    return bindings.Count() > 0 ? this.RenderReferences(bindings) : Enumerable.Empty<string>();
                }
                return Enumerable.Empty<string>();
            }
        }
        public IEnumerable<Angular.ModelProperty> GeoProperties => this.Properties.Where(p => p.IsGeo);
        public bool HasGeoFields => this.Options.GeoJson && this.GeoProperties.Count() > 0;
        public override object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                Entity = new {
                    Name = this.Entity.Name
                }
            };
        }
    }
}