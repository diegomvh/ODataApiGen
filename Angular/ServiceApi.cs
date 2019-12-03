using System;
using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceApi : Service
    {
        public Models.EntityContainer EntityContainer { get; private set; }
        public string EndpointName {get; private set;}
        public ServiceApi(string name, EntityContainer container)
        {
            EndpointName = name;
            EntityContainer = container;
        }
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.EntityContainer.ActionImports.Select(a => a.Action))
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.EntityContainer.FunctionImports.Select(f => f.Function))
                    parameters.AddRange(cal.Parameters);

                var list = new List<string>();
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(this.EntityContainer.ActionImports.Select(ai => ai.Action).SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EntityContainer.FunctionImports.Select(fi => fi.Function).SelectMany(a => this.CallableNamespaces(a)));
                return list;
            }
        }

        public override IEnumerable<Import> Imports => GetImportRecords();

        public override string ResourcePath => "";
        public override string EntityName => "";
        public override string Name => this.EndpointName + "Service";
        public override string NameSpace => EntityContainer.Schema.Namespace;
        public override string FileName => this.Name.ToLower() + ".service";
        public override string EntityType => "";
        public IEnumerable<string> Actions =>  this.RenderCallables(this.EntityContainer.ActionImports.Select(ai => ai.Action));
        public IEnumerable<string> Functions => this.RenderCallables(this.EntityContainer.FunctionImports.Select(fi => fi.Function));
    }
}