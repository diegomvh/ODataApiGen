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
        public ICollection<Angular.Schema> Schemas { get; private set; } = new List<Angular.Schema>();
        public IEnumerable<Angular.Enum> Enums => this.Schemas.SelectMany(s => s.Enums);
        public IEnumerable<Angular.Entity> Entities => this.Schemas.SelectMany(s => s.Entities);
        public IEnumerable<Angular.Model> Models => this.Schemas.SelectMany(s => s.Models);
        public IEnumerable<Angular.Collection> Collections => this.Schemas.SelectMany(s => s.Collections);
        public Package(ApiOptions options) : base(options)
        {
            this.Module = new Module(this, options);
            Config = new Angular.Config(this, options);
            Index = new Angular.Index(this, options);
        }

        public override void Build()
        {
            foreach (var schema in Program.Metadata.Schemas)
            {
                this.Schemas.Add(new Angular.Schema(schema, this.Options));
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
                    var baseEntity = this.Entities.FirstOrDefault(e => e.EdmStructuredType.IsTypeOf(entity.EdmStructuredType.BaseType));
                    entity.SetBase(baseEntity);
                    entity.Dependencies.Add(baseEntity);
                }
            }
            // Models
            foreach (var model in Models)
            {
                if (!String.IsNullOrEmpty(model.EdmStructuredType.BaseType))
                {
                    var baseModel = this.Models.FirstOrDefault(e => e.EdmStructuredType.IsTypeOf(model.EdmStructuredType.BaseType));
                    model.SetBase(baseModel);
                    model.Dependencies.Add(baseModel);
                }
                var collection = this.Collections.FirstOrDefault(m => m.EdmStructuredType.Name == model.EdmStructuredType.Name);
                if (collection != null)
                {
                    model.SetCollection(collection);
                }
            }
            // Collections
            foreach (var collection in Collections)
            {
                if (!String.IsNullOrEmpty(collection.EdmStructuredType.BaseType))
                {
                    var baseCollection = this.Collections.FirstOrDefault(e => e.EdmStructuredType.IsTypeOf(collection.EdmStructuredType.BaseType));
                    collection.SetBase(baseCollection);
                    collection.Dependencies.Add(baseCollection);
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
                if (renderable is Enum || renderable is EnumConfig || renderable is Structured || renderable is Service)
                {
                    renderable.Dependencies.AddRange(
    this.Enums.Where(e => e != renderable && types.Any(type => e.EdmEnumType.IsTypeOf(type))));
                    if (renderable is Structured || renderable is Service)
                    {
                        renderable.Dependencies.AddRange(
        this.Entities.Where(e => e != renderable && types.Any(type => e.EdmStructuredType.IsTypeOf(type))));
                        if (!(renderable is EnumConfig))
                        {
                            {
                                renderable.Dependencies.AddRange(
                this.Models.Where(e => e != renderable && types.Any(type => e.EdmStructuredType.IsTypeOf(type))));
                                renderable.Dependencies.AddRange(
                this.Collections.Where(e => e != renderable && types.Any(type => e.EdmStructuredType.IsTypeOf(type))));
                            }
                        }
                    }
                }
            }

            // Module
            this.Module.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Containers.Select(c => c.Service)));
            this.Module.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services)));
            // Config
            this.Config.Dependencies.AddRange(this.Schemas);
            // Index
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Enums));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.EnumConfigs));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Entities));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Models));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Collections));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.EntityConfigs));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Containers.Select(c => c.Service)));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services)));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.ServiceConfigs)));
            this.Index.Dependencies.Add(this.Config);
            this.Index.Dependencies.Add(this.Module);
        }

        public IEnumerable<string> GetAllDirectories()
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