using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class Package : ODataApiGen.Abstracts.Package, ILiquidizable
    {
        public Angular.Module Module { get; private set; }
        public Angular.Config Config { get; private set; }
        public Angular.Index Index { get; private set; }
        public ICollection<Angular.Enum> Enums { get; private set; }
        public ICollection<Angular.Entity> Entities { get; private set; }
        public ICollection<Angular.Collection> Collections { get; private set; }
        public ICollection<Angular.Service> Services { get; private set; }

        public Package(string endpointName, string metadataPath, bool secure, bool stringAsEnums, bool models, string version) : base(endpointName, metadataPath, secure, stringAsEnums, models, version)
        {
            this.Module = new Module(this);
            Config = new Angular.Config(this);
            Index = new Angular.Index(this);
            Enums = new List<Angular.Enum>();
            Entities = new List<Angular.Entity>();
            Collections = new List<Angular.Collection>();
            Services = new List<Angular.Service>();
        }

        public override void LoadMetadata(Metadata metadata)
        {
            this.Services.Add(new Angular.ServiceApi(this.EndpointName, metadata));
            foreach (var schema in metadata.Schemas) {
                this.AddEnums(schema.EnumTypes);
                this.AddEntities(schema.ComplexTypes);
                this.AddEntities(schema.EntityTypes);
                foreach (var container in schema.EntityContainers) {
                    this.AddServices(container);
                }
            }
        }

        public void AddEnums(IEnumerable<Models.EnumType> enums)
        {
            foreach (var e in enums)
            {
                this.Enums.Add(new Angular.Enum(e));
            }
        }

        public void AddEntities(IEnumerable<Models.EntityType> entities)
        {
            foreach (var t in entities)
            {
                if (this.CreateModels)
                {
                    var model = new Angular.Model(t);
                    this.Entities.Add(model);
                    this.Collections.Add(new Angular.Collection(t, model));
                } else {
                    var inter = new Angular.Interface(t);
                    this.Entities.Add(inter);
                }
            }
        }

        public void AddEntities(IEnumerable<Models.ComplexType> complexs)
        {
            foreach (var t in complexs)
            {
                if (this.CreateModels)
                {
                    var model = new Angular.Model(t);
                    this.Entities.Add(model);
                    this.Collections.Add(new Angular.Collection(t, model));
                } else {
                    var inter = new Angular.Interface(t);
                    this.Entities.Add(inter);
                }
            }
        }

        public void AddServices(Models.EntityContainer container)
        {
            foreach (var s in container.EntitySets)
            {
                this.Services.Add(new Angular.ServiceEntity(s));
            }
            foreach (var s in container.Singletons)
            {
                this.Services.Add(new Angular.ServiceSingleton(s));
            }
        }

        public void ResolveDependencies()
        {
            foreach (var enumm in Enums)
            {
            }
            foreach (var entity in Entities)
            {
                if (!String.IsNullOrEmpty(entity.EdmStructuredType.BaseType))
                {
                    var baseInter = this.Entities.FirstOrDefault(e => e.EdmStructuredType.FullName == entity.EdmStructuredType.BaseType);
                    entity.SetBase(baseInter);
                }
                var types = entity.ImportTypes;
                entity.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.FullName)));
                entity.Dependencies.AddRange(
this.Entities.Where(e => e != entity && types.Contains(e.EdmStructuredType.FullName)));
            }
            foreach (var service in Services)
            {
                var entity = this.Entities.FirstOrDefault(m => m.EdmStructuredType.Name == service.EntityName);
                if (entity != null)
                {
                    service.SetEntity(entity);
                    entity.SetService(service);
                }
                var collection = this.Collections.FirstOrDefault(m => m.EdmStructuredType.Name == service.EntityName);
                if (collection != null)
                {
                    service.SetCollection(collection);
                    collection.SetService(service);
                }
                var types = service.ImportTypes;
                service.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.FullName)));
                service.Dependencies.AddRange(
this.Entities.Where(e => types.Contains(e.EdmStructuredType.FullName)));
                service.Dependencies.AddRange(
this.Collections.Where(e => types.Contains(e.EdmStructuredType.FullName)));
            }
            this.Module.Dependencies.AddRange(this.Services);
            this.Config.Dependencies.AddRange(this.Enums);
            this.Config.Dependencies.AddRange(this.Entities);
            this.Config.Dependencies.AddRange(this.Collections);
            this.Index.Dependencies.AddRange(this.Enums);
            this.Index.Dependencies.AddRange(this.Entities);
            this.Index.Dependencies.AddRange(this.Collections);
            this.Index.Dependencies.AddRange(this.Services);
        }

        public IEnumerable<string> GetAllDirectories()
        {
            return this.Enums.Select(e => e.Directory)
                .Union(this.Entities.Select(m => m.Directory))
                .Union(this.Collections.Select(m => m.Directory))
                .Union(this.Services.Select(s => s.Directory))
                .Distinct();
        }

        public object ToLiquid()
        {
            return new
            {
                BaseUrl = this.MetadataPath.TrimEnd("$metadata".ToCharArray()),
                MetadataUrl = this.MetadataPath,
                WithCredentials = this.WithCredentials.ToString().ToLower(),
                StringAsEnum = this.StringAsEnum.ToString().ToLower(),
                Creation = DateTime.Now,
                Version = this.Version,
                Endpoint = this.EndpointName.ToLower()
            };
        }

        public override IEnumerable<Renderable> Renderables
        {
            get
            {
                var renderables = new List<Renderable>();
                renderables.AddRange(this.Enums);
                renderables.AddRange(this.Entities);
                renderables.AddRange(this.Services);
                renderables.Add(this.Module);
                renderables.Add(this.Config);
                renderables.Add(this.Index);
                return renderables;
            }
        }
    }
}