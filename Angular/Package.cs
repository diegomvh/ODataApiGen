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
        public Package(string name, string serviceRootUrl) : base(name, serviceRootUrl)
        {
            this.Module = new Module(this);
            Config = new Angular.Config(this);
            Index = new Angular.Index(this);
        }

        public override void Build(bool models)
        {
            foreach (var schema in Program.Metadata.Schemas)
            {
                this.Schemas.Add(new Angular.Schema(schema, models));
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
                    var baseEntity = this.Entities.FirstOrDefault(e => e.EdmStructuredType.FullName == entity.EdmStructuredType.BaseType);
                    entity.SetBase(baseEntity);
                    entity.Dependencies.Add(baseEntity);
                }
            }
            // Models
            foreach (var model in Models)
            {
                if (!String.IsNullOrEmpty(model.EdmStructuredType.BaseType))
                {
                    var baseModel = this.Models.FirstOrDefault(e => e.EdmStructuredType.FullName == model.EdmStructuredType.BaseType);
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
                    var baseCollection = this.Collections.FirstOrDefault(e => e.EdmStructuredType.FullName == collection.EdmStructuredType.BaseType);
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
                Name = this.Name.ToLower(),
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