using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class Package : ODataApiGen.Abstracts.Package, ILiquidizable
    {
        public Angular.Module Module { get; private set; }
        public Angular.Config Config { get; private set; }
        public Angular.Index Index { get; private set; }
        public ICollection<Angular.Enum> Enums { get; private set; }
        public ICollection<Angular.Entity> Entities { get; private set; }
        public ICollection<Angular.Model> Models { get; private set; }
        public ICollection<Angular.Collection> Collections { get; private set; }
        public ICollection<Angular.Service> Services { get; private set; }

        public Package(string endpointName, string metadataPath, bool secure, bool stringAsEnums, bool models, string version) : base(endpointName, metadataPath, secure, stringAsEnums, models, version)
        {
            this.Module = new Module(this);
            Config = new Angular.Config(this);
            Index = new Angular.Index(this);
            Enums = new List<Angular.Enum>();
            Entities = new List<Angular.Entity>();
            Models = new List<Angular.Model>();
            Collections = new List<Angular.Collection>();
            Services = new List<Angular.Service>();
        }

        public override void LoadMetadata(MetadataReader reader)
        {
            this.AddEnums(reader.EnumTypes);
            this.AddModels(reader.ComplexTypes);
            this.AddModels(reader.EntityTypes);
            this.AddServices(reader.EntitySets);
            this.AddServices(reader.Singletons);
        }

        public void AddEnums(IEnumerable<Models.EnumType> enums)
        {
            foreach (var e in enums)
            {
                this.Enums.Add(new Angular.Enum(e));
            }
        }

        public void AddModels(IEnumerable<Models.EntityType> entities)
        {
            foreach (var t in entities)
            {
                if (this.CreateModels)
                {
                    var model = new Angular.Model(t);
                    this.Models.Add(model);
                    this.Collections.Add(new Angular.Collection(t, model));
                } else {
                    var inter = new Angular.Entity(t);
                    this.Entities.Add(inter);
                }
            }
        }

        public void AddModels(IEnumerable<Models.ComplexType> complexs)
        {
            foreach (var t in complexs)
            {
                if (this.CreateModels)
                {
                    var model = new Angular.Model(t);
                    this.Models.Add(model);
                    this.Collections.Add(new Angular.Collection(t, model));
                } else {
                    var entity = new Angular.Entity(t);
                    this.Entities.Add(entity);
                }
            }
        }

        public void AddServices(IEnumerable<Models.EntitySet> sets)
        {
            foreach (var s in sets)
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
        }
        public void AddServices(IEnumerable<Models.Singleton> singletons)
        {
            foreach (var s in singletons)
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
                    var baseInter = this.Entities.FirstOrDefault(e => e.EdmStructuredType.Type == entity.EdmStructuredType.BaseType);
                    entity.SetBase(baseInter);
                }
                var types = entity.ImportTypes;
                entity.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type)));
                entity.Dependencies.AddRange(
this.Entities.Where(e => e != entity && types.Contains(e.EdmStructuredType.Type)));
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
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type)));
                model.Dependencies.AddRange(
this.Entities.Where(e => types.Contains(e.EdmStructuredType.Type)));
                model.Dependencies.AddRange(
this.Models.Where(e => e != model && types.Contains(e.EdmStructuredType.Type)));
                model.Dependencies.AddRange(
this.Collections.Where(e => types.Contains(e.EdmStructuredType.Type)));
            }
            foreach (var service in Services)
            {
                var entity = this.Entities.FirstOrDefault(m => m.EdmStructuredType.Name == service.EdmEntityName);
                if (entity != null)
                {
                    service.SetEntity(entity);
                    entity.SetService(service);
                }
                var model = this.Models.FirstOrDefault(m => m.EdmStructuredType.Name == service.EdmEntityName);
                if (model != null)
                {
                    service.SetModel(model);
                    model.SetService(service);
                }
                var collection = this.Collections.FirstOrDefault(m => m.EdmStructuredType.Name == service.EdmEntityName);
                if (collection != null)
                {
                    service.SetCollection(collection);
                    collection.SetService(service);
                }
                var types = service.ImportTypes;
                service.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type)));
                service.Dependencies.AddRange(
this.Entities.Where(e => types.Contains(e.EdmStructuredType.Type)));
                service.Dependencies.AddRange(
this.Models.Where(e => types.Contains(e.EdmStructuredType.Type)));
                service.Dependencies.AddRange(
this.Collections.Where(e => types.Contains(e.EdmStructuredType.Type)));
            }
            this.Module.Dependencies.AddRange(this.Services);
            this.Config.Dependencies.AddRange(this.Enums);
            this.Config.Dependencies.AddRange(this.Entities);
            this.Config.Dependencies.AddRange(this.Models);
            this.Config.Dependencies.AddRange(this.Collections);
            this.Index.Dependencies.AddRange(this.Enums);
            this.Index.Dependencies.AddRange(this.Entities);
            this.Index.Dependencies.AddRange(this.Models);
            this.Index.Dependencies.AddRange(this.Collections);
            this.Index.Dependencies.AddRange(this.Services);
        }

        public IEnumerable<string> GetAllDirectories()
        {
            return this.Enums.Select(e => e.Directory)
                .Union(this.Entities.Select(m => m.Directory))
                .Union(this.Models.Select(m => m.Directory))
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
                renderables.AddRange(this.Models);
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