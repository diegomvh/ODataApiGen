using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Abstracts;
using Microsoft.Extensions.Logging;

namespace Od2Ts.Angular
{
    public class Module : Renderable
    {
        public static ILogger Logger { get; } = Program.CreateLogger<Module>();
        public bool UseReferences { get; private set; }
        public string EndpointName { get; private set; }
        public override string Name => this.EndpointName + "Module";
        public override string FileName => this.EndpointName.ToLower() + ".module";
        public override string Directory => "";
        public override IEnumerable<string> Types
        {
            get
            {
                return Services.Select(a => a.EdmEntitySet.EntityType);
            }
        }
        public Angular.Index Index { get; private set; }
        public ICollection<Angular.Enum> Enums { get; private set; }
        public ICollection<Angular.Interface> Interfaces { get; private set; }
        public ICollection<Angular.Service> Services { get; private set; }
        public ICollection<Angular.Model> Models { get; private set; }

        public Module(string endpointName, bool useReferences)
        {
            EndpointName = endpointName;
            UseReferences = useReferences;
            Index = new Angular.Index(this);
            Enums = new List<Angular.Enum>();
            Interfaces = new List<Angular.Interface>();
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

        public void AddInterfaces(IEnumerable<Models.EntityType> entities)
        {
            foreach (var m in entities)
            {
                this.Interfaces.Add(new Angular.Interface(m));
            }
        }

        public void AddInterfaces(IEnumerable<Models.ComplexType> complexs)
        {
            foreach (var c in complexs)
            {
                this.Interfaces.Add(new Angular.Interface(c));
            }
        }

        public void AddServices(IEnumerable<Models.EntitySet> sets)
        {
            foreach (var s in sets)
            {
                this.Services.Add(new Angular.Service(s, UseReferences));
            }
        }

        public void AddModels(IEnumerable<Models.EntitySet> sets)
        {
            foreach (var s in sets)
            {
                this.Models.Add(new Angular.Model(s));
            }
        }

        public void ResolveDependencies()
        {
            foreach (var enumm in Enums)
            {
            }
            foreach (var inter in Interfaces)
            {
                if (!String.IsNullOrEmpty(inter.EdmStructuredType.BaseType))
                {
                    var baseInter = this.Interfaces.FirstOrDefault(m => m.EdmStructuredType.Type == inter.EdmStructuredType.BaseType);
                    inter.SetBase(baseInter);
                }
                var types = inter.Types;
                inter.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type))
                );
                inter.Dependencies.AddRange(
this.Interfaces.Where(e => e != inter && types.Contains(e.EdmStructuredType.Type))
                );
            }
            foreach (var service in Services)
            {
                var inter = this.Interfaces.FirstOrDefault(m => m.EdmStructuredType.Name == service.EdmEntityTypeName);
                if (inter != null)
                {
                    service.SetInterface(inter);
                }
                var types = service.Types;
                service.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type))
                );
                service.Dependencies.AddRange(
this.Interfaces.Where(e => types.Contains(e.EdmStructuredType.Type))
                );
            }
            foreach (var model in Models)
            {
                var service = this.Services.FirstOrDefault(s => s.Interface.EdmStructuredType.Type == model.EdmEntitySet.EntityType);
                if (service != null)
                {
                    model.SetService(service);
                }
                if (!String.IsNullOrEmpty(model.Service.Interface.EdmStructuredType.BaseType))
                {
                    var baseModel = this.Models.FirstOrDefault(m => m.Service.Interface.EdmStructuredType.Type == model.Service.Interface.EdmStructuredType.BaseType);
                    model.SetBase(baseModel);
                }
                var types = model.Types;
                model.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type))
                );
                model.Dependencies.AddRange(
this.Interfaces.Where(e => types.Contains(e.EdmStructuredType.Type))
                );
                model.Dependencies.AddRange(
this.Models.Where(e => types.Contains(e.Type))
                );
            }
            this.Dependencies.AddRange(this.Services);
            this.Index.Dependencies.AddRange(this.Enums);
            this.Index.Dependencies.AddRange(this.Interfaces);
            this.Index.Dependencies.AddRange(this.Services);
            this.Index.Dependencies.AddRange(this.Models);
        }

        public IEnumerable<string> GetAllDirectories()
        {
            return this.Enums.Select(e => e.Directory)
                .Union(this.Interfaces.Select(m => m.Directory))
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
