using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceEntity : Service
    {
        public Models.EntitySet EdmEntitySet { get; private set; }
        public ServiceEntity(EntitySet type) {
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
                list.AddRange(this.Entity.EdmStructuredType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.Entity.EdmStructuredType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.Entity.EdmStructuredType.Properties.Select(a => a.Type));
                list.AddRange(this.EdmEntitySet.NavigationPropertyBindings.Select(b => b.EntityType.FullName));
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
        public override string EntityName => EdmEntitySet.EntityType.Split('.').Last();
        public override string EntityType => this.EdmEntitySet.EntityType;
        public string ServiceType => this.EdmEntitySet.FullName;
        public override string Name => this.EdmEntitySet.Name[0].ToString().ToUpper() + this.EdmEntitySet.Name.Substring(1) + "Service";
        public override string NameSpace => this.EdmEntitySet.Namespace;
        public override string FileName => this.EdmEntitySet.Name.ToLower() + ".service";
        public IEnumerable<string> Actions =>  this.RenderCallables(this.EdmEntitySet.Actions.Union(this.Entity.EdmStructuredType.Actions));
        public IEnumerable<string> Functions => this.RenderCallables(this.EdmEntitySet.Functions.Union(this.Entity.EdmStructuredType.Functions));
        public IEnumerable<string> Navigations => this.RenderReferences(this.EdmEntitySet.NavigationPropertyBindings);
    }
}