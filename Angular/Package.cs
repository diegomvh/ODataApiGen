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
        public ICollection<Angular.BaseModel> BaseModels { get; private set; }
        public ICollection<Angular.Model> Models { get; private set; }
        public ICollection<Angular.Meta> Metas { get; private set; }
        public ICollection<Angular.BaseCollection> BaseCollections { get; private set; }
        public ICollection<Angular.Collection> Collections { get; private set; }
        public ICollection<Angular.Service> Services { get; private set; }

        public Package(string endpointName, string metadataPath, bool secure, bool stringAsEnums, bool models, string version) : base(endpointName, metadataPath, secure, stringAsEnums, models, version)
        {
            this.Module = new Module(this);
            Config = new Angular.Config(this);
            Index = new Angular.Index(this);
            Enums = new List<Angular.Enum>();
            Entities = new List<Angular.Entity>();
            BaseModels = new List<Angular.BaseModel>();
            Models = new List<Angular.Model>();
            Metas = new List<Angular.Meta>();
            BaseCollections = new List<Angular.BaseCollection>();
            Collections = new List<Angular.Collection>();
            Services = new List<Angular.Service>();
        }

        public override void LoadMetadata(Metadata metadata)
        {
            this.Services.Add(new Angular.ServiceApi(this.EndpointName, metadata));
            foreach (var schema in metadata.Schemas)
            {
                this.AddEnums(schema.EnumTypes);
                this.AddComplexes(schema.ComplexTypes);
                this.AddEntities(schema.EntityTypes);
                foreach (var container in schema.EntityContainers)
                {
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
                var meta = new Angular.Meta(t);
                this.Metas.Add(meta);
                var inter = new Angular.Entity(t, meta);
                this.Entities.Add(inter);
                if (this.CreateModels)
                {
                    var baseModel = new Angular.BaseModel(t, inter);
                    this.BaseModels.Add(baseModel);
                    var model = new Angular.Model(t, inter, baseModel);
                    baseModel.SetModel(model);
                    this.Models.Add(model);
                    var baseCollection = new Angular.BaseCollection(t, baseModel);
                    this.BaseCollections.Add(baseCollection);
                    var collection = new Angular.Collection(t, model, baseCollection);
                    baseCollection.SetCollection(collection);
                    this.Collections.Add(collection);
                }
            }
        }

        public void AddComplexes(IEnumerable<Models.ComplexType> complexes)
        {
            foreach (var t in complexes)
            {
                var meta = new Angular.Meta(t);
                this.Metas.Add(meta);
                var inter = new Angular.Entity(t, meta);
                this.Entities.Add(inter);
                if (this.CreateModels)
                {
                    var baseModel = new Angular.BaseModel(t, inter);
                    this.BaseModels.Add(baseModel);
                    var model = new Angular.Model(t, inter, baseModel);
                    baseModel.SetModel(model);
                    this.Models.Add(model);
                    var baseCollection = new Angular.BaseCollection(t, baseModel);
                    this.BaseCollections.Add(baseCollection);
                    var collection = new Angular.Collection(t, model, baseCollection);
                    baseCollection.SetCollection(collection);
                    this.Collections.Add(collection);
                }
            }
        }

        public void AddServices(Models.EntityContainer container)
        {
            foreach (var s in container.EntitySets)
            {
                if (this.CreateModels)
                {
                    this.Services.Add(new Angular.ServiceModel(s));
                }
                else
                {
                    this.Services.Add(new Angular.ServiceEntity(s));
                }
            }
            foreach (var s in container.Singletons)
            {
                this.Services.Add(new Angular.ServiceSingleton(s));
            }
        }

        public void ResolveDependencies()
        {
            // Enums
            foreach (var enumm in Enums)
            {
            }
            // Entities
            foreach (var entity in Entities)
            {
                if (!String.IsNullOrEmpty(entity.EdmStructuredType.BaseType))
                {
                    var baseInter = this.Entities.FirstOrDefault(e => e.EdmStructuredType.FullName == entity.EdmStructuredType.BaseType);
                    entity.SetBase(baseInter);
                    entity.Dependencies.Add(baseInter);
                }
                var service = this.Services.FirstOrDefault(s => s.EntityName == entity.EdmStructuredType.Name);
                if (service != null)
                {
                    entity.SetService(service);
                }
            }
            // Metas
            // root casma
            foreach (var meta in Metas)
            {
                if (!String.IsNullOrEmpty(meta.EdmStructuredType.BaseType))
                {
                    var baseInter = this.Metas.FirstOrDefault(e => e.EdmStructuredType.FullName == meta.EdmStructuredType.BaseType);
                    meta.SetBase(baseInter);
                }
                var service = this.Services.FirstOrDefault(s => s.EntityName == meta.EdmStructuredType.Name);
                if (service != null)
                {
                    meta.SetService(service);
                }
            }
            // Base Models
            foreach (var baseModel in BaseModels)
            {
                if (!String.IsNullOrEmpty(baseModel.EdmStructuredType.BaseType))
                {
                    var baseInter = this.BaseModels.FirstOrDefault(e => e.EdmStructuredType.FullName == baseModel.EdmStructuredType.BaseType);
                    baseModel.SetBase(baseInter);
                    baseModel.Dependencies.Add(baseInter);
                }
                var baseCollection = this.BaseCollections.FirstOrDefault(m => m.EdmStructuredType.Name == baseModel.EdmStructuredType.Name);
                if (baseCollection != null)
                {
                    baseModel.SetCollection(baseCollection);
                }
                var service = this.Services.FirstOrDefault(s => s.EntityName == baseModel.EdmStructuredType.Name);
                if (service != null)
                {
                    baseModel.SetService(service);
                }
            }

            // Models
            foreach (var model in Models)
            {
                if (!String.IsNullOrEmpty(model.EdmStructuredType.BaseType))
                {
                    var baseInter = this.Models.FirstOrDefault(e => e.EdmStructuredType.FullName == model.EdmStructuredType.BaseType);
                    model.SetBase(baseInter);
                    model.Dependencies.Add(baseInter);
                }
                var collection = this.Collections.FirstOrDefault(m => m.EdmStructuredType.Name == model.EdmStructuredType.Name);
                if (collection != null)
                {
                    model.SetCollection(collection);
                }
                var service = this.Services.FirstOrDefault(s => s.EntityName == model.EdmStructuredType.Name);
                if (service != null)
                {
                    model.SetService(service);
                }
            }
            // Base Collections
            foreach (var baseCollection in BaseCollections)
            {
                if (!String.IsNullOrEmpty(baseCollection.EdmStructuredType.BaseType))
                {
                    var baseInter = this.BaseCollections.FirstOrDefault(e => e.EdmStructuredType.FullName == baseCollection.EdmStructuredType.BaseType);
                    baseCollection.SetBase(baseInter);
                    baseCollection.Dependencies.Add(baseInter);
                }
                var service = this.Services.FirstOrDefault(s => s.EntityName == baseCollection.EdmStructuredType.Name);
                if (service != null)
                {
                    baseCollection.SetService(service);
                }
            }
            // Collections
            foreach (var collection in Collections)
            {
                if (!String.IsNullOrEmpty(collection.EdmStructuredType.BaseType))
                {
                    var baseInter = this.BaseCollections.FirstOrDefault(e => e.EdmStructuredType.FullName == collection.EdmStructuredType.BaseType);
                    collection.SetBase(baseInter);
                    collection.Dependencies.Add(baseInter);
                }
                var service = this.Services.FirstOrDefault(s => s.EntityName == collection.EdmStructuredType.Name);
                if (service != null)
                {
                    collection.SetService(service);
                }
            }
            // Services
            foreach (var service in Services)
            {
                var inter = this.Entities.FirstOrDefault(m => m.EdmStructuredType.Name == service.EntityName);
                if (inter != null)
                {
                    service.SetInterface(inter);
                }
                var model = this.Models.FirstOrDefault(m => m.EdmStructuredType.Name == service.EntityName);
                if (model != null)
                {
                    service.SetModel(model);
                }
                var collection = this.Collections.FirstOrDefault(m => m.EdmStructuredType.Name == service.EntityName);
                if (collection != null)
                {
                    service.SetCollection(collection);
                }
            }
            // Resolve Renderables
            var renderables = new List<Renderable>();
            renderables.AddRange(this.Enums);
            renderables.AddRange(this.Metas);
            renderables.AddRange(this.Entities);
            renderables.AddRange(this.BaseModels);
            renderables.AddRange(this.Models);
            renderables.AddRange(this.BaseCollections);
            renderables.AddRange(this.Collections);
            renderables.AddRange(this.Services);
            foreach (var renderable in renderables)
            {
                var types = renderable.ImportTypes;
                if (renderable is Enum || renderable is Structured || renderable is Service)
                {
                    renderable.Dependencies.AddRange(
    this.Enums.Where(e => e != renderable && types.Contains(e.EdmEnumType.FullName)));
                    if (renderable is Structured || renderable is Service)
                    {
                        renderable.Dependencies.AddRange(
        this.Entities.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                        if (renderable is Model || renderable is Entity || renderable is Service)
                        {
                            renderable.Dependencies.AddRange(
            this.BaseModels.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                            renderable.Dependencies.AddRange(
            this.Models.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                            renderable.Dependencies.AddRange(
            this.BaseCollections.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                            renderable.Dependencies.AddRange(
            this.Collections.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                        }
                    }
                }
            }
            this.Module.Dependencies.AddRange(this.Services);
            this.Config.Dependencies.AddRange(this.Enums);
            this.Config.Dependencies.AddRange(this.Entities);
            this.Config.Dependencies.AddRange(this.Models);
            this.Config.Dependencies.AddRange(this.Metas);
            this.Config.Dependencies.AddRange(this.Collections);
            this.Index.Dependencies.AddRange(this.Enums);
            this.Index.Dependencies.AddRange(this.Entities);
            this.Index.Dependencies.AddRange(this.Models);
            this.Index.Dependencies.AddRange(this.Metas);
            this.Index.Dependencies.AddRange(this.Collections);
            this.Index.Dependencies.AddRange(this.Services);
        }

        public IEnumerable<string> GetAllDirectories()
        {
            return this.Enums.Select(e => e.Directory)
                .Union(this.Entities.Select(m => m.Directory))
                .Union(this.Models.Select(m => m.Directory))
                .Union(this.Metas.Select(m => m.Directory))
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
                renderables.AddRange(this.BaseModels);
                renderables.AddRange(this.Models);
                renderables.AddRange(this.Metas);
                renderables.AddRange(this.BaseCollections);
                renderables.AddRange(this.Collections);
                renderables.AddRange(this.Services);
                renderables.Add(this.Module);
                renderables.Add(this.Config);
                renderables.Add(this.Index);
                return renderables;
            }
        }
    }
}