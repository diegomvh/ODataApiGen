using System.Collections.Generic;
using System.Linq;
using System;
using ODataApiGen.Models;
using Newtonsoft.Json;
using System.IO;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class Container: AngularRenderable, DotLiquid.ILiquidizable 
    {
        public Models.EntityContainer EdmEntityContainer {get; private set;}
        public Angular.ContainerConfig Config {get; private set;}
        public ICollection<Angular.Service> Services { get; } = new List<Angular.Service>();
        public ICollection<Angular.ServiceConfig> ServiceConfigs { get; } = new List<Angular.ServiceConfig>();
        public Container(EntityContainer container, bool models) {
            this.EdmEntityContainer = container;
            this.Config = new Angular.ContainerConfig(container);
            foreach (var eset in container.EntitySets)
            {
                var config = new Angular.ServiceConfig(eset);
                if (models)
                {
                    this.Services.Add(new Angular.ServiceModel(eset));
                }
                else
                {
                    this.Services.Add(new Angular.ServiceEntity(eset));
                }
                this.ServiceConfigs.Add(config);
            }
            foreach (var s in container.Singletons)
            {
                var config = new Angular.ServiceConfig(s);
                this.Services.Add(new Angular.ServiceSingleton(s));
                this.ServiceConfigs.Add(config);
            }
        }
        public override string FileName => this.EdmEntityContainer.Name.ToLower() + ".container";
        public override string Name => this.EdmEntityContainer.Name + "Container";

        public string Annotations {
            get {
                return JsonConvert.SerializeObject(this.EdmEntityContainer.Annotations.Select(annot => annot.ToDictionary()), Formatting.Indented);
            }
        }
        public string ContainerType => this.EdmEntityContainer.FullName;
        public string ApiName => this.EdmEntityContainer.Name;
        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { this.ContainerType };
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Namespace => this.EdmEntityContainer.Namespace;
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public void ResolveDependencies(IEnumerable<Angular.Enum> enums, IEnumerable<Angular.Entity> entities, IEnumerable<Angular.Model> models, IEnumerable<Angular.Collection> collections) {
            // Services
            foreach (var service in Services)
            {
                var inter = entities.FirstOrDefault(m => m.EdmStructuredType.Name == service.EntityName);
                if (inter != null)
                {
                    service.SetEntity(inter);
                }
                var model = models.FirstOrDefault(m => m.EdmStructuredType.Name == service.EntityName);
                if (model != null)
                {
                    service.SetModel(model);
                }
                var collection = collections.FirstOrDefault(m => m.EdmStructuredType.Name == service.EntityName);
                if (collection != null)
                {
                    service.SetCollection(collection);
                }
            }

            // Resolve Renderable Dependencies
            var renderables = new List<Renderable>();
            renderables.AddRange(this.Services);
            renderables.AddRange(this.ServiceConfigs);
            foreach (var renderable in renderables)
            {
                var types = renderable.ImportTypes;
                if (renderable is Enum || renderable is EnumConfig || renderable is Structured || renderable is Service)
                {
                    renderable.Dependencies.AddRange(
    enums.Where(e => e != renderable && types.Contains(e.EdmEnumType.FullName)));
                    if (renderable is Structured || renderable is Service)
                    {
                        renderable.Dependencies.AddRange(
        entities.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                        if (!(renderable is EnumConfig))
                        {
                            {
                                renderable.Dependencies.AddRange(
                models.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                                renderable.Dependencies.AddRange(
                collections.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                            }
                        }
                    }
                }
            }
            this.Dependencies.AddRange(this.ServiceConfigs);
        }
        public IEnumerable<string> GetAllDirectories()
        {
            return this.Services.Select(s => s.Directory)
                .Union(this.ServiceConfigs.Select(s => s.Directory));
        }
        public IEnumerable<Renderable> Renderables
        {
            get
            {
                var renderables = new List<Renderable>();
                renderables.AddRange(this.Services);
                renderables.AddRange(this.ServiceConfigs);
                return renderables;
            }
        }
        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                ContainerType = this.ContainerType
            };
        }
    }
}