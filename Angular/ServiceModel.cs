using System;
using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceModel : Service
    {
        public Models.EntitySet EdmEntitySet { get; private set; }
        public ServiceModel(EntitySet type) {
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
                list.AddRange(this.Entity.EdmStructuredType.NavigationProperties.Select(a => a.Type));
                return list;
            }
        }

        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string ResourcePath => this.EdmEntitySet.Name;
        public override string EntityName => EdmEntitySet.EntityType.Split('.').Last();
        public override string Name => this.EdmEntitySet.Name[0].ToString().ToUpper() + this.EdmEntitySet.Name.Substring(1) + "Service";
        public override string NameSpace => this.EdmEntitySet.Namespace;
        public override string FileName => this.EdmEntitySet.Name.ToLower() + ".service";
        public override string EntityType => this.EdmEntitySet.EntityType;
        public IEnumerable<string> Actions =>  this.RenderCallables(this.EdmEntitySet.Actions.Union(this.Entity.EdmStructuredType.Actions));
        public IEnumerable<string> Functions => this.RenderCallables(this.EdmEntitySet.Functions.Union(this.Entity.EdmStructuredType.Functions));
        public IEnumerable<string> Navigations => this.RenderReferences(this.Entity.EdmStructuredType.NavigationProperties);
    }
}