using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Abstracts;
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
        public Uri Uri { get { return this.BuildUri(NameSpace, Name); }}
        public IEnumerable<Import> Imports
        {
            get
            {
                return Enumerable.Empty<Import>();
            }
        }
        public string EndpointName {get; private set;}
        public override string Name => this.EndpointName;

        public override string NameSpace => String.Empty;
        public override string Render()
        {
            var exportModels = this.EntityTypes.Select(type => this.BuildUri(type.NameSpace, type.Name));
            var exportServices = this.EntitySets.Select(set => this.BuildUri(set.NameSpace, set.Name));

            return $@"{String.Join("\n", exportModels)}
            {String.Join("\n", exportServices)}
            export * from './{this.EndpointName.ToLower()}.module'";
        }
    }
}
