using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
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

        public override string Name => this.EdmSingleton.Name[0].ToString().ToUpper() + this.EdmSingleton.Name.Substring(1) + "Service";
        public override string NameSpace => this.EdmSingleton.Namespace;
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
                if (this.Interface != null)
                {
                    list.AddRange(this.Interface.EdmStructuredType.Properties.Select(a => a.Type));
                    if (this.Interface.EdmStructuredType is EntityType)
                        list.AddRange((this.Interface.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
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
        public override string ResourcePath => this.EdmSingleton.Name;
        public override string EntityName => this.EdmSingleton.Type.Split('.').Last();
        public override string EntityType => this.EdmSingleton.Type;
        public IEnumerable<string> Actions =>  this.RenderCallables(this.EdmSingleton.Actions);
        public IEnumerable<string> Functions => this.RenderCallables(this.EdmSingleton.Functions);
    }
}