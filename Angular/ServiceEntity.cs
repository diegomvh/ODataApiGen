using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceEntity : Service
    {
        public Models.EntitySet EdmEntitySet { get; private set; }
        public ServiceEntity(EntitySet type, ApiOptions options) : base(options) {
            EdmEntitySet = type;
        }
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.EdmEntitySet.Actions)
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.EdmEntitySet.Functions)
                    parameters.AddRange(cal.Parameters);

                var list = new List<string> {
                    this.EdmEntitySet.EntityType
                };
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(this.EdmEntitySet.Actions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmEntitySet.Functions.SelectMany(a => this.CallableNamespaces(a)));
                if (this.Entity != null)
                {
                    if (this.Entity.EdmEntityType != null) {
                        list.AddRange(this.Entity.EdmEntityType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                        list.AddRange(this.Entity.EdmEntityType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                    }
                    list.AddRange(this.Entity.EdmStructuredType.Properties.Select(a => a.Type));
                }
                list.AddRange(this.EdmEntitySet.NavigationPropertyBindings.Select(b => b.NavigationProperty.Type));
                list.AddRange(this.EdmEntitySet.NavigationPropertyBindings.Select(b => b.PropertyType).Where(t => t != null).Select(t => t.FullName));
                return list;
            }
        }

        public string EntitySetAnnotations {
            get {
                return JsonConvert.SerializeObject(this.EdmEntitySet.Annotations.Select(annot => annot.ToDictionary()));
            }
        }
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string EntitySetName => this.EdmEntitySet.Name;
        public override string EntityName => this.Entity.Name; 
        public override string EntityType => this.EdmEntitySet.EntityType;
        public string ServiceType => this.EdmEntitySet.FullName;
        public override string Name => AngularRenderable.ToTypescriptName(this.EdmEntitySet.Name, TypeScriptElement.Class) + "Service";
        public override string Namespace => this.EdmEntitySet.Namespace;
        public override string FileName => this.EdmEntitySet.Name.ToLower() + ".service";
        public IEnumerable<string> Actions =>  this.RenderCallables(this.EdmEntitySet.Actions.Union(this.Entity.EdmEntityType.Actions));
        public IEnumerable<string> Functions => this.RenderCallables(this.EdmEntitySet.Functions.Union(this.Entity.EdmEntityType.Functions));
        public IEnumerable<string> Navigations => this.RenderReferences(this.EdmEntitySet.NavigationPropertyBindings);
        public override IEnumerable<Models.Annotation> Annotations => this.EdmEntitySet.Annotations; 
    }
}