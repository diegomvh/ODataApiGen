using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Abstracts;
using Od2Ts.Extensions;
using Od2Ts.Interfaces;

namespace Od2Ts.Angular
{
    public class Index : Renderable, IHasImports
    {
        public Angular.Module Module {get; private set;}
        public Index(Angular.Module module )
        {
            this.Module = module;
        }
        public Uri Uri { get { return this.BuildUri(Name); }}
        public IEnumerable<Import> Imports
        {
            get
            {
                var imports = new List<Import>();
                imports.AddRange(Module.Models.Select(a => new Import(this.BuildUri(a.NameSpace, a.Name))));
                imports.AddRange(Module.Services.Select(a => new Import(this.BuildUri(a.NameSpace, a.Name))));
                return imports;
            }
        }
        public override string Name => this.Module.EndpointName;

        public override string NameSpace => String.Empty;
        public override string Render()
        {
            var exports = this.GetImportRecords().Select(record => $"export * from './{record.RelativeNamespace}';");

            return $@"{String.Join("\n", exports)}
            
export * from './{this.Module.EndpointName.ToLower()}.module'";
        }
    }
}
