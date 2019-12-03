using System;
using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceApi : Service
    {
        public Models.Metadata Metadata { get; private set; }
        public string EndpointName {get; private set;}
        public ServiceApi(string name, Metadata metadata)
        {
            EndpointName = name;
            Metadata = metadata;
        }
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.Metadata.UnboundActions)
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.Metadata.UnboundFunctions)
                    parameters.AddRange(cal.Parameters);

                var list = new List<string>();
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(this.Metadata.UnboundActions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.Metadata.UnboundFunctions.SelectMany(f => this.CallableNamespaces(f)));
                return list;
            }
        }

        public override IEnumerable<Import> Imports => GetImportRecords();

        public override string ResourcePath => "";
        public override string EntityName => "";
        public override string Name => this.EndpointName + "Service";
        public override string NameSpace => "";
        public override string FileName => this.Name.ToLower() + ".service";
        public override string EntityType => "";
        public IEnumerable<string> Actions =>  this.RenderCallables(this.Metadata.UnboundActions);
        public IEnumerable<string> Functions => this.RenderCallables(this.Metadata.UnboundFunctions);
    }
}