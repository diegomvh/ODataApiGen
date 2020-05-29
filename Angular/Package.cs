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
        public ICollection<Angular.Schema> Schemas { get; private set; }
        public Package(string name) : base(name)
        {
            this.Module = new Module(this);
            Config = new Angular.Config(this);
            Index = new Angular.Index(this);
            Schemas = new List<Angular.Schema>();
        }

        public override void Build(bool models)
        {
            foreach (var schema in Program.Metadata.Schemas)
            {
                this.Schemas.Add(new Angular.Schema(schema, this.Name, models));
            }
        }
        public void ResolveDependencies()
        {
            foreach (var schema in Schemas)
                schema.ResolveDependencies();
            /*
            // Resolve Renderable Dependencies
            var renderables = new List<Renderable>();
            renderables.AddRange(this.ApiConfigs);
            renderables.AddRange(this.Enums);
            renderables.AddRange(this.EnumConfigs);
            renderables.AddRange(this.Entities);
            renderables.AddRange(this.Models);
            renderables.AddRange(this.Collections);
            renderables.AddRange(this.EntityConfigs);
            renderables.AddRange(this.Services);
            renderables.AddRange(this.ServiceConfigs);
            foreach (var renderable in renderables)
            {
                var types = renderable.ImportTypes;
                if (renderable is Enum || renderable is EnumConfig || renderable is Structured || renderable is Service)
                {
                    renderable.Dependencies.AddRange(
    this.Enums.Where(e => e != renderable && types.Contains(e.EdmEnumType.FullName)));
                    if (renderable is Structured || renderable is Service)
                    {
                        renderable.Dependencies.AddRange(
        this.Entities.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                        if (!(renderable is EnumConfig))
                        {
                            {
                                renderable.Dependencies.AddRange(
                this.Models.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                                renderable.Dependencies.AddRange(
                this.Collections.Where(e => e != renderable && types.Contains(e.EdmStructuredType.FullName)));
                            }
                        }
                    }
                }
            }
            // Module
            this.Module.Dependencies.AddRange(this.Services);
            // Config
            this.Config.Dependencies.AddRange(this.ApiConfigs);
            this.Config.Dependencies.AddRange(this.EnumConfigs);
            this.Config.Dependencies.AddRange(this.EntityConfigs);
            this.Config.Dependencies.AddRange(this.ServiceConfigs);
            this.Config.Dependencies.AddRange(this.ApiConfigs);
            // Index
            this.Index.Dependencies.AddRange(this.Enums);
            this.Index.Dependencies.AddRange(this.EnumConfigs);
            this.Index.Dependencies.AddRange(this.Entities);
            this.Index.Dependencies.AddRange(this.Models);
            this.Index.Dependencies.AddRange(this.Collections);
            this.Index.Dependencies.AddRange(this.EntityConfigs);
            this.Index.Dependencies.AddRange(this.Services);
            this.Index.Dependencies.AddRange(this.ServiceConfigs);
            */
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
                ServiceRootUrl = this.MetadataPath.TrimEnd("$metadata".ToCharArray()),
                Creation = DateTime.Now,
                Endpoint = this.Name.ToLower()
            };
        }

        public override IEnumerable<Renderable> Renderables
        {
            get
            {
                var renderables = new List<Renderable>();
                renderables.AddRange(this.Schemas.SelectMany(s => s.Renderables));
                renderables.Add(this.Module);
                renderables.Add(this.Config);
                renderables.Add(this.Index);
                return renderables;
            }
        }
    }
}