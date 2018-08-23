using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Abstracts;
using Od2Ts.Interfaces;

namespace Od2Ts.Angular
{
    public class Module : Renderable, IHasImports
    {
        public bool UseInterfaces {get; private set;}
        public bool UseReferences {get; private set;}
        public string EndpointName {get; private set;}
        public override string Name => this.EndpointName;
        public override string NameSpace => String.Empty;
        public Angular.Index Index {get; private set;}
        public ICollection<Angular.Enum> Enums {get; private set;}
        public ICollection<Angular.Model> Models {get; private set;}
        public ICollection<Angular.Service> Services {get; private set;}

        public Module(string endpointName, bool useInterfaces, bool useReferences)
        {
            EndpointName = endpointName;
            UseInterfaces = useInterfaces;
            UseReferences = useReferences;
            Index = new Angular.Index(this);
            Enums = new List<Angular.Enum>();
            Models = new List<Angular.Model>();
            Services = new List<Angular.Service>();
        }

        public void AddEnums(IEnumerable<Models.EnumType> enums) {
            foreach (var e in enums)
            {
                this.Enums.Add(new Angular.Enum(e));
            }
        }

        public void AddModels(IEnumerable<Models.EntityType> entities) {
            foreach (var m in entities)
            {
                this.Models.Add(new Angular.Model(m, UseInterfaces));
            }
            ResolveRelations();
        }

        public void AddModels(IEnumerable<Models.ComplexType> complexs) {
            foreach (var c in complexs)
            {
                this.Models.Add(new Angular.Model(c, UseInterfaces));
            }
            ResolveRelations();
        }

        public void AddServices(IEnumerable<Models.EntitySet> sets) {
            foreach (var s in sets)
            {
                this.Services.Add(new Angular.Service(s, UseReferences));
            }
            ResolveRelations();
        }

        private void ResolveRelations() {
            foreach (var service in Services) {
                var model = this.Models.FirstOrDefault(m => m.EdmStructuredType.Name == service.EdmEntityTypeName);
                if (model != null) {
                    service.SetModel(model);
                }
            }
        }

        public IEnumerable<string> GetAllNamespaces() {
            return this.Enums.Select(e => e.NameSpace)
                .Union(this.Models.Select(m => m.NameSpace))
                .Union(this.Services.Select(s => s.NameSpace))
                .Distinct();
        }

        public Uri Uri { get { return this.BuildUri(Name); }}
        public IEnumerable<Import> Imports
        {
            get
            {
                var list = new List<Import>
                {
                    new Import(this.BuildUri($"{this.EndpointName}Context"))
                };
                list.AddRange(Services.Select(a => new Import(this.BuildUri(a.NameSpace, a.Name))));
                return list;
            }
        }
        public override string Render()
        {
            var imports = this.RenderImports(this);

            return $@"import {{ NgModule }} from '@angular/core';
import {{ CommonModule }} from '@angular/common';

{String.Join("\n", imports)}

@NgModule({{
  providers: [
    {String.Join(",\n    ", this.Services.Select(set => set.Name))}
  ]
}})
export class {this.Name}Module {{ }}";
        }
    }
}
