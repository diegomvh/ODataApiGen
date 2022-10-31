using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Flutter
{
    public class Package : ODataApiGen.Abstracts.Package, ILiquidizable
    {
        public Flutter.Module Module { get; private set; }
        public Flutter.ApiConfig Config { get; private set; }
        public Flutter.Index Index { get; private set; }
        public ICollection<Flutter.Schema> Schemas { get; private set; } = new List<Flutter.Schema>();
        public IEnumerable<Flutter.Enum> Enums => this.Schemas.SelectMany(s => s.Enums);
        public Enum FindEnum(string type) {
            return this.Enums.FirstOrDefault(m => m.EdmEnumType.IsTypeOf(type));
        }
        public IEnumerable<Flutter.Entity> Entities => this.Schemas.SelectMany(s => s.Entities);
        public Entity FindEntity(string type) {
            return this.Entities.FirstOrDefault(m => m.EdmStructuredType.IsTypeOf(type));
        }
        public IEnumerable<Flutter.Model> Models => this.Schemas.SelectMany(s => s.Models);
        public Model FindModel(string type) {
            return this.Models.FirstOrDefault(m => m.EdmStructuredType.IsTypeOf(type));
        }
        public IEnumerable<Flutter.Collection> Collections => this.Schemas.SelectMany(s => s.Collections);
        public Collection FindCollection(string type) {
            return this.Collections.FirstOrDefault(m => m.EdmStructuredType.IsTypeOf(type));
        }
        public Package(ApiOptions options) : base(options)
        {
            this.Module = new Module(this, options);
            Config = new Flutter.ApiConfig(this, options);
            Index = new Flutter.Index(this, options);
        }

        public override void Build()
        {
            foreach (var schema in Program.Metadata.Schemas)
            {
                this.Schemas.Add(new Flutter.Schema(schema, this.Options));
            }
        }
        public override void ResolveDependencies()
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
                    var baseEntity = this.Entities.FirstOrDefault(e => e.EdmStructuredType.IsTypeOf(entity.EdmStructuredType.BaseType));
                    entity.SetBase(baseEntity);
                    entity.AddDependency(baseEntity);
                }
            }
            // Models
            foreach (var model in Models)
            {
                if (!String.IsNullOrEmpty(model.EdmStructuredType.BaseType))
                {
                    var baseModel = this.Models.FirstOrDefault(e => e.EdmStructuredType.IsTypeOf(model.EdmStructuredType.BaseType));
                    model.SetBase(baseModel);
                    model.AddDependency(baseModel);
                }
                var collection = this.Collections.FirstOrDefault(m => m.EdmStructuredType.Name == model.EdmStructuredType.Name);
                if (collection != null)
                {
                    model.SetCollection(collection);
                    //model.AddDependency(collection);
                }
            }
            // Collections
            foreach (var collection in Collections)
            {
                if (!String.IsNullOrEmpty(collection.EdmStructuredType.BaseType))
                {
                    var baseCollection = this.Collections.FirstOrDefault(e => e.EdmStructuredType.IsTypeOf(collection.EdmStructuredType.BaseType));
                    collection.SetBase(baseCollection);
                    collection.AddDependency(baseCollection);
                }
            }

            foreach (var schema in Schemas)
            {
                schema.ResolveDependencies();
                foreach (var container in schema.Containers)
                {
                    container.ResolveDependencies(this.Enums, this.Entities, this.Models, this.Collections);
                }
            }

            // Resolve Renderable Dependencies
            foreach (var renderable in this.Renderables)
            {
                var types = renderable.ImportTypes;
                if (renderable is Enum || renderable is EnumTypeConfig || renderable is Entity || renderable is Model || renderable is Collection || renderable is Service)
                {
                    renderable.AddDependencies(
    this.Enums.Where(e => e != renderable && types.Any(type => e.EdmEnumType.IsTypeOf(type))));
                    if (renderable is Entity || renderable is Model || renderable is Collection || renderable is Service)
                    {
                        renderable.AddDependencies(
        this.Entities.Where(e => e != renderable && types.Any(type => e.EdmStructuredType.IsTypeOf(type))));
                        if (!(renderable is EnumTypeConfig))
                        {
                            {
                                renderable.AddDependencies(
                this.Models.Where(e => e != renderable && types.Any(type => e.EdmStructuredType.IsTypeOf(type))));
                                renderable.AddDependencies(
                this.Collections.Where(e => e != renderable && types.Any(type => e.EdmStructuredType.IsTypeOf(type))));
                            }
                        }
                    }
                }
            }

            // Module
            this.Module.AddDependencies(this.Schemas.SelectMany(s => s.Containers.Select(c => c.Service)));
            this.Module.AddDependencies(this.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services)));
            // Config
            this.Config.AddDependencies(this.Schemas);
            // Index
            this.Index.AddDependencies(this.Schemas.SelectMany(s => s.Enums));
            this.Index.AddDependencies(this.Schemas.SelectMany(s => s.EnumConfigs));
            this.Index.AddDependencies(this.Schemas.SelectMany(s => s.Entities));
            this.Index.AddDependencies(this.Schemas.SelectMany(s => s.Models));
            this.Index.AddDependencies(this.Schemas.SelectMany(s => s.Collections));
            this.Index.AddDependencies(this.Schemas.SelectMany(s => s.EntityConfigs));
            this.Index.AddDependencies(this.Schemas.SelectMany(s => s.Containers.Select(c => c.Service)));
            this.Index.AddDependencies(this.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services)));
            this.Index.AddDependencies(this.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.EntitySetConfigs)));
            this.Index.AddDependency(this.Config);
            this.Index.AddDependency(this.Module);
        }

        public override IEnumerable<string> GetAllDirectories()
        {
            return this.Schemas.SelectMany(s => s.GetAllDirectories())
                .Distinct();
        }

        public object ToLiquid()
        {
            return new
            {
                Name = this.Name,
                ServiceRootUrl = this.ServiceRootUrl,
                Version = this.Version,
                Creation = DateTime.Now,
                Schemas = this.Schemas
            };
        }

        public override IEnumerable<Renderable> Renderables
        {
            get
            {
                var renderables = new List<Renderable>();
                renderables.Add(this.Module);
                renderables.Add(this.Config);
                renderables.Add(this.Index);
                renderables.AddRange(this.Schemas);
                renderables.AddRange(this.Schemas.SelectMany(s => s.Renderables));
                return renderables;
            }
        }
    }
}