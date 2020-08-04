using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceModel : Service
    {
        public Models.EntitySet EdmEntitySet { get; private set; }
        public ServiceModel(EntitySet type, ApiOptions options) : base(options) {
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
                if (this.Model.EdmEntityType != null) {
                    list.AddRange(this.Model.EdmEntityType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                    list.AddRange(this.Model.EdmEntityType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                }
                list.AddRange(this.Model.EdmStructuredType.Properties.Select(a => a.Type));
                if (this.Model.EdmStructuredType is EntityType)
                    list.AddRange((this.Model.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
                return list;
            }
        }

        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string EntitySetName => this.EdmEntitySet.Name;
        public override string EntityType => this.EdmEntitySet.EntityType;
        public override string EntityName => this.Entity.Name;
        public string ModelName => this.Model.Name;
        public string CollectionName => this.Collection.Name;
        public string ServiceType => this.EdmEntitySet.FullName;
        public override string Name => AngularRenderable.ToTypescriptName(this.EdmEntitySet.Name, TypeScriptElement.Class) + "Service";
        public override string Namespace => this.EdmEntitySet.Namespace;
        public override string FileName => this.EdmEntitySet.Name.ToLower() + ".service";
        public override IEnumerable<Models.Annotation> Annotations => this.EdmEntitySet.Annotations; 
        public IEnumerable<string> Actions =>  this.RenderCallables(this.EdmEntitySet.Actions.Union(this.Model.EdmEntityType.Actions));
        public IEnumerable<string> Functions => this.RenderCallables(this.EdmEntitySet.Functions.Union(this.Model.EdmEntityType.Functions));
        public IEnumerable<string> Navigations => this.RenderReferences(this.EdmEntitySet.NavigationPropertyBindings);
        public string EntitySetAnnotations {
            get {
                return JsonConvert.SerializeObject(this.EdmEntitySet.Annotations.Select(annot => annot.ToDictionary()));
            }
        }
    }
}