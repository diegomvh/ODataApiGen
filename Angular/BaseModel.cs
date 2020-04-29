using System.Collections.Generic;
using System.Linq;
using System.IO;
using ODataApiGen.Models;
using System;

namespace ODataApiGen.Angular
{
    public class BaseProperty : StructuredProperty 
    {
        public AngularRenderable Renderable {get; private set;}
        public BaseProperty(ODataApiGen.Models.Property prop, AngularRenderable type) : base(prop)
        {
            this.Renderable = type;
        }
        public override string Name {
            get {
                var required = !(Value is NavigationProperty || Value.Nullable);
                var annot = Value.FindAnnotation<CoreComputedAnnotation>("Org.OData.Core.V1.Computed");
                if (annot != null)
                    required = annot.Bool;
                return Value.Name + (!required? "?" : "");
            }
        }
        public override string Type { get {
            var type = AngularRenderable.GetTypescriptType(Value.Type);
            if (this.Renderable is Enum) {
                return type;
            }
            if (Value.IsCollection)
                return type + (Value.IsEdmType ? "[]" : $"Collection<{type}, {type}Model<{type}>>");
            else 
                return type + (Value.IsEdmType ? "" : $"Model<{type}>");
        }}
    }
    public class BaseModel : Structured 
    {
        public Angular.Entity Interface { get; private set; }

        public BaseModel(StructuredType type, Angular.Entity inter) : base(type) {
            this.Interface = inter;
            this.Dependencies.Add(inter);
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

        public override IEnumerable<Angular.StructuredProperty> Properties {
            get {
                var props = this.EdmStructuredType.Properties.ToList();
                if (this.EdmStructuredType is EntityType) 
                    props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
                return props.Select(prop => {
                    var type = this.Dependencies.FirstOrDefault(dep => dep.Type == prop.Type);
                    return new Angular.BaseProperty(prop, type as AngularRenderable); 
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
                Interface = new {
                    Name = this.Interface.Name
                }
            };
        }
    }
}