using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;
using DotLiquid;

namespace ODataApiGen.Angular
{
    public class BaseModelProperty : ILiquidizable
    {
        protected Models.Property Value { get; set; }
        public BaseModelProperty(ODataApiGen.Models.Property prop)
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

        public string Type { get {
            var type = AngularRenderable.GetTypescriptType(Value.Type);
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
    }
    public class BaseModel : Structured 
    {
        public Angular.Entity Entity { get; private set; }

        public BaseModel(StructuredType type, Angular.Entity entity) : base(type) {
            this.Entity = entity;
            this.Dependencies.Add(entity);
        }
        public Angular.Model Model {get; private set;}

        public void SetModel(Model model)
        {
            this.Model = model;
            this.Dependencies.Add(model);
        }
        public Angular.BaseCollection BaseCollection {get; private set;}

        public void SetCollection(BaseCollection collection)
        {
            this.BaseCollection = collection;
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model.base";
        public override string Name => this.EdmStructuredType.Name + "BaseModel";
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
                if (this.Model.Base != null) {
                    list.Add(this.Model.Base.EdmStructuredType.FullName);
                }
                return list;
            }
        }
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

        public IEnumerable<Angular.BaseModelProperty> Properties {
            get {
                var props = this.EdmStructuredType.Properties.ToList();
                if (this.EdmStructuredType is EntityType) 
                    props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
                return props.Select(prop => new Angular.BaseModelProperty(prop));
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
                    var modelNavigations = (this.EdmStructuredType as EntityType).NavigationProperties.Where(nav => !nav.IsCollection);
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
                EntityType = this.EntityType,
                Model = new {
                    Name = this.Model.Name
                },
                Entity = new {
                    Name = this.Entity.Name
                }
            };
        }
    }
}