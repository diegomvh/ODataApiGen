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
        public Index(string endpointName, IEnumerable<Models.EntityType> entityTypes, IEnumerable<Models.EntitySet> entitySets)
        {
            EntitySets = entitySets;
            EntityTypes = entityTypes;
            EndpointName = endpointName;
        }
        public readonly IEnumerable<Models.EntitySet> EntitySets;
        public readonly IEnumerable<Models.EntityType> EntityTypes;
        public Uri Uri { get { return this.BuildUri(Name); }}
        public IEnumerable<Import> Imports
        {
            get
            {
                var imports = new List<Import>();
                imports.AddRange(this.EntityTypes.Select(type => new Import(this.BuildUri(type.NameSpace, type.Name))));
                imports.AddRange(this.EntitySets.Select(set => new Import(this.BuildUri(set.NameSpace, set.Name))));
                return imports;
            }
        }
        public string EndpointName {get; private set;}
        public override string Name => this.EndpointName;

        public override string NameSpace => String.Empty;
        public override string Render()
        {
            var exports = this.GetImportRecords().Select(record => $"export * from './{record.RelativeNamespace}';");

            return $@"{String.Join("\n", exports)}
export * from './{this.EndpointName.ToLower()}.module'";
        }
    }
}
