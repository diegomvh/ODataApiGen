using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using Newtonsoft.Json;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceSingleton : Service 
    {
        public Models.Singleton EdmSingleton { get; private set; }

        public ServiceSingleton(Models.Singleton type)
        {
            EdmSingleton = type;
        }
        public override string Name => this.EdmSingleton.Name.Substring(0, 1).ToUpper() + this.EdmSingleton.Name.Substring(1) + "Service";
        public override string Namespace => this.EdmSingleton.Namespace;
        public override string FileName => this.EdmSingleton.Name.ToLower() + ".service";
        // Imports
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.EdmSingleton.Actions)
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.EdmSingleton.Functions)
                    parameters.AddRange(cal.Parameters);

                var list = new List<string> {
                    this.EdmSingleton.Type
                };
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(this.EdmSingleton.Actions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmSingleton.Functions.SelectMany(a => this.CallableNamespaces(a)));
                if (this.Entity != null)
                {
                    list.AddRange(this.Entity.EdmStructuredType.Properties.Select(a => a.Type));
                    if (this.Entity.EdmStructuredType is EntityType)
                        list.AddRange((this.Entity.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
                }
                if (this.Model != null)
                {
                    list.AddRange(this.Model.EdmStructuredType.Properties.Select(a => a.Type));
                    if (this.Model.EdmStructuredType is EntityType)
                        list.AddRange((this.Model.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
                }
                return list;
            }
        }

        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override string EntitySetName => this.EdmSingleton.Name;
        public override string EntityName => this.EdmSingleton.Type.Split('.').Last();
        public override string EntityType => this.EdmSingleton.Type;
        public override IEnumerable<Models.Annotation> Annotations => this.EdmSingleton.Annotations; 
        public string ServiceType => this.EdmSingleton.FullName;
        public IEnumerable<string> Actions =>  this.RenderCallables(this.EdmSingleton.Actions);
        public IEnumerable<string> Functions => this.RenderCallables(this.EdmSingleton.Functions);
        public string EntitySetAnnotations {
            get {
                return JsonConvert.SerializeObject(this.EdmSingleton.Annotations.Select(annot => annot.ToDictionary()));
            }
        }
    }
}