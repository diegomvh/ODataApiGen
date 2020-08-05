using System.Collections.Generic;
using System.Linq;
using System;
using ODataApiGen.Models;
using Newtonsoft.Json;
using DotLiquid;
using System.IO;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class EntityFieldConfig : ILiquidizable
    {
        protected Models.Property Value { get; set; }
        protected IEnumerable<PropertyRef> Keys { get; set; }
        protected Angular.EntityConfig Config { get; set; }
        public EntityFieldConfig(Models.Property property, IEnumerable<PropertyRef> keys, Angular.EntityConfig config) {
            this.Keys = keys;
            this.Value = property;
            this.Config = config;
        }
        //public string Name => AngularRenderable.ToTypescriptName(Value.Name, TypeScriptElement.Method);
        public string Name => Utils.IsValidTypeScrtiptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";

        public string Type { 
            get {
                var values = new Dictionary<string, string>();
                if (this.Name != this.Value.Name)
                    values.Add("name", $"'{this.Value.Name}'");
                if (this.Value.Type != null) {
                    values.Add("type", $"'{this.Value.Type}'");
                }
                else if (this.Value is NavigationProperty) {
                    var nav = this.Value as NavigationProperty;
                    values.Add("type", $"'{nav.ToEntityType}'");
                }
                var key = this.Keys.FirstOrDefault(k => k.Name == this.Value.Name);
                if (key != null) {
                    values.Add("key", "true");
                    values.Add("ref", $"'{this.Name}'");
                    if (!String.IsNullOrWhiteSpace(key.Alias)) {
                        values.Add("alias", $"'{key.Alias}'");
                    }
                }
                if (!(this.Value is NavigationProperty) && !this.Value.Nullable)
                    values.Add("nullable", "false");
                if (!String.IsNullOrEmpty(this.Value.MaxLength) && this.Value.MaxLength.ToLower() != "max")
                    values.Add("maxLength", this.Value.MaxLength);
                if (!String.IsNullOrEmpty(this.Value.DefaultValue))
                    values.Add("default", $"'{this.Value.DefaultValue}'");
                if (!String.IsNullOrEmpty(this.Value.SRID))
                    values.Add("srid", this.Value.SRID);
                if (!String.IsNullOrEmpty(this.Value.Precision))
                    values.Add("precition", this.Value.Precision);
                if (!String.IsNullOrEmpty(this.Value.Scale))
                    values.Add("scale", this.Value.Scale);
                if (this.Value.IsCollection || this.Value is NavigationProperty && (this.Value as NavigationProperty).Many)
                    values.Add("collection", "true");
                if (this.Value is NavigationProperty) {
                    // Is Navigation
                    values.Add("navigation", "true");
                    var nav = this.Value as NavigationProperty;
                    if (!String.IsNullOrEmpty(nav.ReferentialConstraint))
                        values.Add("field", $"'{nav.ReferentialConstraint}'");
                    if (!String.IsNullOrEmpty(nav.ReferencedProperty))
                        values.Add("ref", $"'{nav.ReferencedProperty}'");
                }
                var annots = this.Value.Annotations;
                if (annots.Count > 0) {
                    var json = JsonConvert.SerializeObject(annots.Select(annot => annot.ToDictionary()));
                    values.Add("annotations", $"{json}");
                }
                return $"{{{String.Join(", ", values.Select(p => $"{p.Key}: {p.Value}"))}}}";
            }
        } 
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
    }
    public class EntityConfig : AngularRenderable, DotLiquid.ILiquidizable
    {
        public Angular.Entity Entity {get; private set;}
        public Angular.Model Model {get; private set;}
        public Angular.Collection Collection {get; private set;}
        public EntityConfig(Angular.Entity entity, ApiOptions options) : base(options) {
            this.Entity = entity;
            this.Dependencies.Add(entity);
        }
        public EntityConfig(Angular.Entity entity, Angular.Model model, Angular.Collection collection, ApiOptions options) : this(entity, options) {
            this.Model = model;
            this.Collection = collection;
            this.Dependencies.Add(model);
            this.Dependencies.Add(collection);
        }
        public override string FileName => this.Entity.FileName + ".config";
        public override string Name => this.Entity.Name + "Config";
        public string EntityType => this.Entity.EdmStructuredType.FullName;
        public string EntityName => this.Entity.Name;
        public bool OpenType => this.Entity.OpenType; 

        public string Annotations {
            get {
                return JsonConvert.SerializeObject(this.Entity.EdmStructuredType.Annotations.Select(annot => annot.ToDictionary()));
            }
        }

        public IEnumerable<Angular.EntityFieldConfig> Properties {
            get {
                var props = this.Entity.EdmStructuredType.Properties.ToList();
                if (this.Entity.EdmStructuredType is EntityType) 
                    props.AddRange((this.Entity.EdmStructuredType as EntityType).NavigationProperties);
                var keys = (this.Entity.EdmStructuredType is EntityType) ? (this.Entity.EdmStructuredType as EntityType).Keys : new List<PropertyRef>();
                return props.Select(prop => new EntityFieldConfig(prop, keys, this));
            }
        }

        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { this.EntityType };
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override string Namespace => this.Entity.EdmStructuredType.Namespace;
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public override IEnumerable<Import> Imports => GetImportRecords();

        public Angular.Structured Base => this.Entity.Base;
        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                EntityName = this.EntityName
            };
        }
    }
}