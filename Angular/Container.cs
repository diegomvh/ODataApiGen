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
        public Angular.ServiceContainer Service { get; private set; }
        public ICollection<Angular.Service> Services { get; } = new List<Angular.Service>();
        public ICollection<Angular.ServiceConfig> ServiceConfigs { get; } = new List<Angular.ServiceConfig>();
        public Container(EntityContainer container, ApiOptions options) : base(options) {
            this.EdmEntityContainer = container;
            this.Service = new Angular.ServiceContainer(this, options);
            foreach (var eset in container.EntitySets)
            {
                Service service;
                if (options.Models)
                {
                    service = new Angular.ServiceModel(eset, options);
                    this.Services.Add(service);
                }
                else
                {
                    service = new Angular.ServiceEntity(eset, options);
                    this.Services.Add(service);
                }
                var config = new Angular.ServiceConfig(service, options);
                this.ServiceConfigs.Add(config);
            }
            foreach (var s in container.Singletons)
            {
                var service = new Angular.ServiceSingleton(s, options);
                this.Services.Add(service);
                var config = new Angular.ServiceConfig(service, options);
                this.ServiceConfigs.Add(config);
            }
        }
        public string Annotations {
            get {
                return JsonConvert.SerializeObject(this.EdmEntityContainer.Annotations.Select(annot => annot.ToDictionary()), Formatting.Indented);
            }
        }
        public override string FileName => this.EdmEntityContainer.Name.ToLower() + ".container";
        public override string Name => this.EdmEntityContainer.Name.Substring(0, 1).ToUpper() + this.EdmEntityContainer.Name.Substring(1) + "Container";
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
                var inter = entities.FirstOrDefault(m => m.EdmStructuredType.IsTypeOf(service.EntityType));
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

            this.Dependencies.AddRange(this.ServiceConfigs);
        }
        public IEnumerable<string> GetAllDirectories()
        {
            return new string[] { this.Service.Directory }
                .Union(this.Services.Select(s => s.Directory))
                .Union(this.ServiceConfigs.Select(s => s.Directory));
        }
        public IEnumerable<Renderable> Renderables
        {
            get
            {
                var renderables = new List<Renderable>();
                renderables.Add(this.Service);
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