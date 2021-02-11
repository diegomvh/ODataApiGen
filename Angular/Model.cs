using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;
using DotLiquid;
using ODataApiGen.Abstracts;
using System;

namespace ODataApiGen.Angular
{
    public class ModelProperty : ILiquidizable
    {
        protected Models.Property Value { get; set; }
        protected Angular.StructuredType Structured { get; set; }
        public ModelProperty(ODataApiGen.Models.Property prop, Angular.StructuredType structured)
        {
            this.Value = prop;
            this.Structured = structured;
        }
        public string Name {
            get {
                var required = !(Value is NavigationProperty || Value.Nullable);
                //return AngularRenderable.ToTypescriptName(Value.Name, TypeScriptElement.Method) + (!required? "?" : "");
                var name = Utils.IsValidTypeScrtiptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";
                return name + (!required? "?" : "!");
            }
        }

        public string Type { get {
            var pkg = Program.Package as Angular.Package;
            if (this.Value.IsEnumType){
                var e = pkg.FindEnum(this.Value.Type);
                return e.ImportedName;
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
                    return $"{collection.ImportedName}<{entity.ImportedName}, {model.ImportedName}<{entity.ImportedName}>>";
                }
                else {
                    var entity = pkg.FindEntity(this.Value.Type);
                    var model = pkg.FindModel(this.Value.Type);
                    return $"{model.ImportedName}<{entity.ImportedName}>";
                }
            } else if (this.Value is NavigationProperty) {
                var nav = this.Value as NavigationProperty;
                if (nav.Many) {
                    var entity = pkg.FindEntity(nav.ToEntityType);
                    var model = pkg.FindModel(nav.ToEntityType);
                    var collection = pkg.FindCollection(nav.ToEntityType);
                    return $"{collection.ImportedName}<{entity.ImportedName}, {model.ImportedName}<{entity.ImportedName}>>";
                }
                else {
                    var entity = pkg.FindEntity(nav.ToEntityType);
                    var model = pkg.FindModel(nav.ToEntityType);
                    return $"{model.ImportedName}<{entity.ImportedName}>";
                }
            }
            return "any";
        }}
        public string Setter(){
            var pkg = Program.Package as Angular.Package;
            var nav = this.Value as NavigationProperty;
            var name = this.Value.Name.Substring(0, 1).ToUpper() + this.Value.Name.Substring(1);
            var setterName = $"set{name}";
            var entity = (this.Value.Type != null) ? 
                pkg.FindEntity(this.Value.Type) :
                pkg.FindEntity(nav.ToEntityType);
            // setter
            return $@"public {setterName}(model: {this.Type} | null, options?: HttpOptions) {{
    return this.setReference<{entity.ImportedName}>('{this.Value.Name}', model, options);
  }}";
        }
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type,
                Setter = this.NeedSetter ? this.Setter() : ""
            };
        }
        public bool IsGeo => this.Value.Type.StartsWith("Edm.Geography") || this.Value.Type.StartsWith("Edm.Geometry");
        public bool NeedSetter => 
                this.Value is NavigationProperty && !this.Value.IsCollection && !(this.Value as NavigationProperty).Many;
    }
    public class Model : StructuredType 
    {
        public Angular.Entity Entity { get; private set; }

        public Model(Models.StructuredType type, Angular.Entity entity, ApiOptions options) : base(type, options) {
            this.Entity = entity;
        }
        public Angular.Collection Collection {get; private set;}

        public void SetCollection(Collection collection)
        {
            this.Collection = collection;
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override string Name => Utils.ToTypescriptName(this.EdmStructuredType.Name, TypeScriptElement.Class) + "Model";
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var list = new List<string> {
                    this.EdmStructuredType.FullName
                };
                list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
                if (this.EdmEntityType != null) {
                    list.AddRange(this.EdmEntityType.Properties.Select(a => a.Type));
                    list.AddRange(this.EdmEntityType.NavigationProperties.Select(a => a.Type));
                    list.AddRange(this.EdmEntityType.NavigationProperties.Select(a => a.ToEntityType));
                    list.AddRange(this.EdmEntityType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                    list.AddRange(this.EdmEntityType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                }
                var service = Program.Metadata.EntitySets.FirstOrDefault(s => this.EdmStructuredType.IsTypeOf(s.EntityType));
                if (service != null) {
                    list.AddRange(service.NavigationPropertyBindings.Select(b => b.NavigationProperty.Type));
                    list.AddRange(service.NavigationPropertyBindings.Select(b => b.PropertyType).Where(t => t != null).Select(t => t.FullName));
                }
                
                return list.Where(t => !String.IsNullOrWhiteSpace(t) && !t.StartsWith("Edm.")).Distinct();
            }
        }
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
                if (this.EdmEntityType != null) {
                    var modelActions = this.EdmEntityType.Actions.Where(a => !a.IsCollection);
                    return modelActions.Count() > 0 ? this.RenderCallables(modelActions) : Enumerable.Empty<string>();
                }
                return Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Functions {
            get {
                if (this.EdmEntityType != null) {
                    var modelFunctions = this.EdmEntityType.Functions.Where(a => !a.IsCollection);
                    return modelFunctions.Count() > 0 ? this.RenderCallables(modelFunctions) : Enumerable.Empty<string>();
                }
                return Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Navigations {
            get {
                var service = Program.Metadata.EntitySets.FirstOrDefault(s => this.EdmStructuredType.IsTypeOf(s.EntityType));
                if (service != null) {
                    var properties = new List<NavigationProperty>(); 
                    var entity = this.EdmEntityType;
                    while (true) {
                        properties.AddRange(entity.NavigationProperties);
                        if (String.IsNullOrEmpty(entity.BaseType))
                            break;
                        entity = Program.Metadata.FindEntityType(entity.BaseType);
                    }
                    var bindings = service.NavigationPropertyBindings
                        .Where(binding => properties.All(n => n.Name != binding.NavigationProperty.Name));
                    return this.RenderNavigationPropertyBindings(bindings);
                }
                return Enumerable.Empty<string>();
            }
        }
        public IEnumerable<Angular.ModelProperty> GeoProperties => this.Properties.Where(p => p.IsGeo);
        public IEnumerable<Angular.ModelProperty> SetterProperties => this.Properties.Where(p => p.NeedSetter);
        public bool HasGeoFields => this.Options.GeoJson && this.GeoProperties.Count() > 0;
        public override object ToLiquid()
        {
            return new {
                Name = this.ImportedName,
                Type = this.Type,
                Entity = new {
                    Name = this.Entity.ImportedName
                }
            };
        }
    }
}