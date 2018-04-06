using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Abstracts;
using Od2Ts.Interfaces;

namespace Od2Ts.Angular
{
    public class Module : Renderable, IHasImports
    {
        public Module(string endpointName, IEnumerable<Models.EntityType> entityTypes, IEnumerable<Models.EntitySet> entitySets)
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
                var list = new List<Import>
                {
                    new Import(this.BuildUri("ODataContext"))
                };
                list.AddRange(EntitySets.Select(a => new Import(this.BuildUri(a.NameSpace, a.Name))));
                return list;
            }
        }
        public string EndpointName {get; private set;}
        public override string Name => this.EndpointName;

        public override string NameSpace => String.Empty;
        public override string Render()
        {
            var imports = this.RenderImports(this);

            return $@"import {{ NgModule }} from '@angular/core';
import {{ CommonModule }} from '@angular/common';
{String.Join("\n", imports)}

@NgModule({{
  providers: [
    {String.Join("\n    ", this.EntitySets.Select(set => $"{set.Name},"))},
    {{ provide: ODataContext, useClass: ODataContext }}
  ]
}})
export class {this.Name}Module {{ }}";
        }
    }
}
