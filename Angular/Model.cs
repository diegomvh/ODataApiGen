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
                //return AngularRenderable.ToTypescriptName(Value.Name, TypeScriptElement.Method) + (!required? "?" : "");
                return Value.Name + (!required? "?" : "");
            }
        }

        public string Type { get {
            var pkg = Program.Package as Angular.Package;
            if (this.Value.IsEnumType){
                var e = pkg.FindEnum(this.Value.Type);
                return e.Name;
            }
            else if (Value.IsEdmType) {
                var type = this.Structured.ToTypescriptType(Value.Type);
                return type + (Value.IsCollection ? "[]" : "");
            }
            else if (this.Value.Type != null) {
                if (Value.IsCollection) {
                    var entity = pkg.FindEntity(this.Value.Type);
                    var model = pkg.FindModel(this.Value.Type);
                    var collection = pkg.FindCollection(this.Value.Type);
                    return $"{collection.Name}<{entity.Name}, {model.Name}<{entity.Name}>>";
                }
                else {
                    var entity = pkg.FindEntity(this.Value.Type);
                    var model = pkg.FindModel(this.Value.Type);
                    return $"{model.Name}<{entity.Name}>";
                }
            } else if (this.Value is NavigationProperty) {
                var nav = this.Value as NavigationProperty;
                if (nav.Many) {
                    var entity = pkg.FindEntity(nav.ToEntityType);
                    var model = pkg.FindModel(nav.ToEntityType);
                    var collection = pkg.FindCollection(nav.ToEntityType);
                    return $"{collection.Name}<{entity.Name}, {model.Name}<{entity.Name}>>";
                }
                else {
                    var entity = pkg.FindEntity(nav.ToEntityType);
                    var model = pkg.FindModel(nav.ToEntityType);
                    return $"{model.Name}<{entity.Name}>";
                }
            }
            return "any";
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
        public override string Name => AngularRenderable.ToTypescriptName(this.EdmStructuredType.Name, TypeScriptElement.Class) + "Model";
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var list = new List<string> {
                    this.EdmStructuredType.FullName
                };
                list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
                if (this.EdmStructuredType != null) {
                    list.AddRange(this.EdmEntityType.NavigationProperties.Select(a => a.Type));
                    list.AddRange(this.EdmEntityType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                    list.AddRange(this.EdmEntityType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                }
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
                var modelActions = this.EdmEntityType.Actions.Where(a => !a.IsCollection);
                return modelActions.Count() > 0 ? this.RenderCallables(modelActions, useset: true) : Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Functions {
            get {
                var modelFunctions = this.EdmEntityType.Functions.Where(a => !a.IsCollection);
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