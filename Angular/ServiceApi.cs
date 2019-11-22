using System;
using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceApi : Service
    {
        public IEnumerable<Models.ActionImport> ActionImports { get; private set; }
        public IEnumerable<Models.FunctionImport> FunctionImports { get; private set; }
        public string EndpointName {get; private set;}
        public ServiceApi(string name, IEnumerable<Models.ActionImport> actions, IEnumerable<Models.FunctionImport> functions)
        {
            EndpointName = name;
            ActionImports = actions;
            FunctionImports = functions;
        }
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.ActionImports.Select(a => a.Action))
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.FunctionImports.Select(f => f.Function))
                    parameters.AddRange(cal.Parameters);

                var list = new List<string>();
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(this.ActionImports.Select(ai => ai.Action).SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.FunctionImports.Select(fi => fi.Function).SelectMany(a => this.CallableNamespaces(a)));
                return list;
            }
        }

        public override IEnumerable<Import> Imports => GetImportRecords();

        public override string ResourcePath => "";
        public override string EntityName => "";
        public override string Name => this.EndpointName + "Service";
        public override string NameSpace => 
            ActionImports.Select(a => a.Action.NameSpace).Union(FunctionImports.Select(f => f.Function.NameSpace)).FirstOrDefault();
        public override string FileName => this.Name.ToLower() + ".service";
        public override string EntityType => "";
        public IEnumerable<string> Actions =>  this.RenderCallables(this.ActionImports.Select(ai => ai.Action));
        public IEnumerable<string> Functions => this.RenderCallables(this.FunctionImports.Select(fi => fi.Function));
    }
}