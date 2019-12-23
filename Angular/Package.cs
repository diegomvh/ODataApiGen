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
        public ICollection<Angular.Model> Models { get; private set; }
        public ICollection<Angular.Schema> Schemas { get; private set; }
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
            Schemas = new List<Angular.Schema>();
            Collections = new List<Angular.Collection>();
            Services = new List<Angular.Service>();
        }

        public override void LoadMetadata(Metadata metadata)
        {
            this.Services.Add(new Angular.ServiceApi(this.EndpointName, metadata));
            foreach (var schema in metadata.Schemas) {
                this.AddEnums(schema.EnumTypes);
                this.AddComplexes(schema.ComplexTypes);
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
                var schema = new Angular.Schema(t);
                this.Schemas.Add(schema);
                var inter = new Angular.Entity(t, schema);
                this.Entities.Add(inter);
                if (this.CreateModels)
                {
                    var model = new Angular.Model(t, inter);
                    this.Models.Add(model);
                    this.Collections.Add(new Angular.Collection(t, model));
                }
            }
        }

        public void AddComplexes(IEnumerable<Models.ComplexType> complexes)
        {
            foreach (var t in complexes)
            {
                var schema = new Angular.Schema(t);
                this.Schemas.Add(schema);
                var inter = new Angular.Entity(t, schema);
                this.Entities.Add(inter);
                if (this.CreateModels)
                {
                    var model = new Angular.Model(t, inter);
                    this.Models.Add(model);
                    this.Collections.Add(new Angular.Collection(t, model));
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
                } else {
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
                var types = enumm.ImportTypes;
                enumm.Dependencies.AddRange(
this.Enums.Where(e => e != enumm && types.Contains(e.EdmEnumType.FullName)));
            }
            // Entities
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
            // Schemas
            foreach (var schema in Schemas)
            {
                if (!String.IsNullOrEmpty(schema.EdmStructuredType.BaseType))
                {
                    var baseInter = this.Schemas.FirstOrDefault(e => e.EdmStructuredType.FullName == schema.EdmStructuredType.BaseType);
                    schema.SetBase(baseInter);
                }
                var types = schema.ImportTypes;
                schema.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.FullName)));
                schema.Dependencies.AddRange(
this.Schemas.Where(s => s != schema && types.Contains(s.EdmStructuredType.FullName)));
            }
            // Models
            foreach (var model in Models)
            {
                var types = model.ImportTypes;
                model.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.FullName)));
                model.Dependencies.AddRange(
this.Models.Where(e => e != model && types.Contains(e.EdmStructuredType.FullName)));
                model.Dependencies.AddRange(
this.Collections.Where(c => types.Contains(c.EdmStructuredType.FullName)));
            }
            // Collections
            foreach (var collection in Collections)
            {
                var types = collection.ImportTypes;
                collection.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.FullName)));
                collection.Dependencies.AddRange(
this.Entities.Where(e => types.Contains(e.EdmStructuredType.FullName)));
                collection.Dependencies.AddRange(
this.Models.Where(e => types.Contains(e.EdmStructuredType.FullName)));
                collection.Dependencies.AddRange(
this.Collections.Where(c => c != collection && types.Contains(c.EdmStructuredType.FullName)));
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
                var types = service.ImportTypes;
                service.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.FullName)));
                service.Dependencies.AddRange(
this.Entities.Where(e => types.Contains(e.EdmStructuredType.FullName)));
                service.Dependencies.AddRange(
this.Models.Where(e => types.Contains(e.EdmStructuredType.FullName)));
                service.Dependencies.AddRange(
this.Collections.Where(e => types.Contains(e.EdmStructuredType.FullName)));
            }
            this.Module.Dependencies.AddRange(this.Services);
            this.Config.Dependencies.AddRange(this.Enums);
            this.Config.Dependencies.AddRange(this.Entities);
            this.Config.Dependencies.AddRange(this.Models);
            this.Config.Dependencies.AddRange(this.Schemas);
            this.Config.Dependencies.AddRange(this.Collections);
            this.Index.Dependencies.AddRange(this.Enums);
            this.Index.Dependencies.AddRange(this.Entities);
            this.Index.Dependencies.AddRange(this.Models);
            this.Index.Dependencies.AddRange(this.Schemas);
            this.Index.Dependencies.AddRange(this.Collections);
            this.Index.Dependencies.AddRange(this.Services);
        }

        public IEnumerable<string> GetAllDirectories()
        {
            return this.Enums.Select(e => e.Directory)
                .Union(this.Entities.Select(m => m.Directory))
                .Union(this.Models.Select(m => m.Directory))
                .Union(this.Schemas.Select(m => m.Directory))
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
                renderables.AddRange(this.Schemas);
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