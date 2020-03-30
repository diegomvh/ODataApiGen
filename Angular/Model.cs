using System.Collections.Generic;
using System.Linq;
using System.IO;
using ODataApiGen.Models;
using System;

namespace ODataApiGen.Angular
{
    public class ModelProperty : StructuredProperty 
    {
        public AngularRenderable Renderable {get; private set;}
        public ModelProperty(ODataApiGen.Models.Property prop, AngularRenderable type) : base(prop)
        {
            this.Renderable = type;
        }
        public override string Name {
            get {
                var required = !(Value is NavigationProperty || Value.Nullable);
                var annot = Value.Annotation("Org.OData.Core.V1.Computed");
                if (annot != null)
                    required = annot.Bool.ToLower() != "true";
                return Value.Name + (!required? "?" : "");
            }
        }
        public override string Type { get {
            var type = AngularRenderable.GetTypescriptType(Value.Type);
            if (this.Renderable is Enum) {
                return type;
            }
            if (Value.Collection)
                return type + (Value.IsEdmType ? "[]" : "Collection");
            else 
                return type + (Value.IsEdmType ? "" : "Model");
        }}
    }
    public class Model : Structured 
    {
        public Angular.Entity Interface { get; private set; }

        public Model(StructuredType type, Angular.Entity inter) : base(type) {
            this.Interface = inter;
            this.Dependencies.Add(inter);
        }
        public Angular.Collection Collection {get; private set;}

        public void SetCollection(Collection collection)
        {
            this.Collection = collection;
            this.Dependencies.Add(collection);
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override string Name => this.EdmStructuredType.Name + "Model";
        public string BaseName => this.EdmStructuredType.Name + "BaseModel";
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var list = new List<string> {
                    this.EntityType
                };
                list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
                list.AddRange(this.EdmStructuredType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmStructuredType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                if (this.EdmStructuredType is EntityType)
                    list.AddRange((this.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
                return list;
            }
        }
        public override IEnumerable<string> ExportTypes => new string[] { this.Name, this.BaseName };

        protected IEnumerable<string> RenderReferences(IEnumerable<Models.NavigationProperty> navigations)
        {
            foreach (var nav in navigations)
            {
                var type = AngularRenderable.GetTypescriptType(nav.Type);
                var name = nav.Name[0].ToString().ToUpper() + nav.Name.Substring(1);

                var methodCreateName = $"set{name}";

                var returnType = $"[{type}, ODataEntityAnnotations]";

                yield return $@"public {methodCreateName}(model: {type}Model | null): Observable<this> {{
    return this.setNavigationProperty<{type}, {type}Model>('{nav.Name}', model);
  }}";
            }
        }
        public override IEnumerable<Angular.StructuredProperty> Properties {
            get {
                var props = this.EdmStructuredType.Properties.ToList();
                if (this.EdmStructuredType is EntityType) 
                    props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
                return props.Select(prop => {
                    var type = this.Dependencies.FirstOrDefault(dep => dep.Type == prop.Type);
                    return new Angular.ModelProperty(prop, type as AngularRenderable); 
                });
            }
        } 
        public IEnumerable<string> Actions {
            get {
                var modelActions = this.EdmStructuredType.Actions.Where(a => !a.IsCollection);
                return modelActions.Count() > 0 ? this.RenderCallables(modelActions) : Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Functions {
            get {
                var modelFunctions = this.EdmStructuredType.Functions.Where(a => !a.IsCollection);
                return modelFunctions.Count() > 0 ? this.RenderCallables(modelFunctions) : Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Navigations {
            get {
                if (this.EdmStructuredType is EntityType) {
                    var modelNavigations = (this.EdmStructuredType as EntityType).NavigationProperties.Where(nav => !nav.Collection);
                    return modelNavigations.Count() > 0 ? this.RenderReferences(modelNavigations) : Enumerable.Empty<string>();
                }
                return Enumerable.Empty<string>();
            }
        }
        public override object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                BaseName = this.BaseName,
                EntityType = this.EntityType,
                Interface = new {
                    Name = this.Interface.Name
                }
            };
        }
    }
}