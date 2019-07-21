using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Od2Ts.Angular
{
    public class Module : Renderable
    {
        public static ILogger Logger { get; } = Program.CreateLogger<Module>();
        public string EndpointName { get; private set; }
        public override string Name => this.EndpointName + "Module";
        public override string FileName => this.EndpointName.ToLower() + ".module";
        public override string Directory => "";
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                return Services.Select(a => a.EdmEntitySet.EntityType);
            }
        }

        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public Angular.Index Index { get; private set; }
        public ICollection<Angular.Enum> Enums { get; private set; }
        public ICollection<Angular.Service> Services { get; private set; }
        public ICollection<Angular.Model> Models { get; private set; }

        public Module(string endpointName)
        {
            EndpointName = endpointName;
            Index = new Angular.Index(this);
            Enums = new List<Angular.Enum>();
            Services = new List<Angular.Service>();
            Models = new List<Angular.Model>();
        }

        public void AddEnums(IEnumerable<Models.EnumType> enums)
        {
            foreach (var e in enums)
            {
                this.Enums.Add(new Angular.Enum(e));
            }
        }

        public void AddModels(IEnumerable<Models.EntityType> entities, bool inter)
        {
            foreach (var m in entities)
            {
                this.Models.Add(new Angular.Model(m, inter));
            }
        }

        public void AddModels(IEnumerable<Models.ComplexType> complexs, bool inter)
        {
            foreach (var c in complexs)
            {
                this.Models.Add(new Angular.Model(c, inter));
            }
        }

        public void AddServices(IEnumerable<Models.EntitySet> sets, bool inter, bool refe)
        {
            foreach (var s in sets)
            {
                this.Services.Add(new Angular.Service(s, inter,  refe));
            }
        }

        public void ResolveDependencies()
        {
            foreach (var enumm in Enums)
            {
            }
            foreach (var model in Models)
            {
                if (!String.IsNullOrEmpty(model.EdmStructuredType.BaseType))
                {
                    var baseInter = this.Models.FirstOrDefault(m => m.EdmStructuredType.Type == model.EdmStructuredType.BaseType);
                    model.SetBase(baseInter);
                }
                var types = model.ImportTypes;
                model.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type))
                );
                model.Dependencies.AddRange(
this.Models.Where(e => e != model && types.Contains(e.EdmStructuredType.Type))
                );
            }
            foreach (var service in Services)
            {
                var inter = this.Models.FirstOrDefault(m => m.EdmStructuredType.Name == service.EdmEntityTypeName);
                if (inter != null)
                {
                    service.SetModel(inter);
                }
                var types = service.ImportTypes;
                service.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type))
                );
                service.Dependencies.AddRange(
this.Models.Where(e => types.Contains(e.EdmStructuredType.Type))
                );
            }
            this.Dependencies.AddRange(this.Services);
            this.Index.Dependencies.AddRange(this.Enums);
            this.Index.Dependencies.AddRange(this.Models);
            this.Index.Dependencies.AddRange(this.Services);
        }

        public IEnumerable<string> GetAllDirectories()
        {
            return this.Enums.Select(e => e.Directory)
                .Union(this.Models.Select(m => m.Directory))
                .Union(this.Services.Select(s => s.Directory))
                .Distinct();
        }

        public override string Render()
        {
            var imports = this.RenderImports();

            return $@"import {{ NgModule }} from '@angular/core';

{String.Join("\n", imports)}

@NgModule({{
  providers: [
    {String.Join(",\n    ", this.Services.Select(set => set.Name))}
  ]
}})
export class {this.Name} {{ }}";
        }
    }
}
