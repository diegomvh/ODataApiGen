using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class SchemaConfig : AngularRenderable, DotLiquid.ILiquidizable
    {
        public Models.Schema EdmSchema { get; private set; }
        public override string FileName => this.EdmSchema.Namespace.Split('.').Last().Dasherize() + ".schema.config";
        public override string Name => Utils.ToTypescriptName(this.EdmSchema.Namespace.Split('.').Last(), TypeScriptElement.Class) + "SchemaConfig";
        public ICollection<Enum> Enums { get; } = new List<Enum>();
        public ICollection<EnumTypeConfig> EnumTypeConfigs { get; } = new List<EnumTypeConfig>();
        public ICollection<Entity> Entities { get; } = new List<Entity>();
        public ICollection<Model> Models { get; } = new List<Model>();
        public ICollection<Collection> Collections { get; } = new List<Collection>();
        public ICollection<StructuredTypeConfig> StructuredTypeConfigs { get; } = new List<StructuredTypeConfig>();
        public ICollection<CallableConfig> CallablesConfigs { get; } = new List<CallableConfig>();
        public ICollection<EntityContainerConfig> Containers { get; } = new List<EntityContainerConfig>();
        public SchemaConfig(Models.Schema schema, ApiOptions options) : base(options)
        {
            this.EdmSchema = schema;
            this.AddEnums(schema.EnumTypes);
            this.AddComplexes(schema.ComplexTypes);
            this.AddEntities(schema.EntityTypes);
            this.AddCallables(schema.Functions);
            this.AddCallables(schema.Actions);
            foreach (var container in schema.EntityContainers)
            {
                this.Containers.Add(new EntityContainerConfig(container, options));
            }
        }
        public void AddEnums(IEnumerable<Models.EnumType> enums)
        {
            foreach (var e in enums)
            {
                var enu = new Enum(e, this.Options);
                this.Enums.Add(enu);
                var config = new EnumTypeConfig(enu, this.Options);
                this.EnumTypeConfigs.Add(config);
            }
        }
        public void AddComplexes(IEnumerable<Models.ComplexType> complexes)
        {
            foreach (var cmplx in complexes)
            {
                StructuredTypeConfig config;
                var entity = new Entity(cmplx, this.Options);
                this.Entities.Add(entity);
                if (this.Options.Models)
                {
                    var model = new Model(cmplx, entity, this.Options);
                    this.Models.Add(model);
                    var collection = new Collection(cmplx, model, this.Options);
                    this.Collections.Add(collection);
                    config = new StructuredTypeConfig(entity, model, collection, this.Options);
                } else {
                    config = new StructuredTypeConfig(entity, this.Options);
                }
                this.StructuredTypeConfigs.Add(config);
            }
        }
        public void AddEntities(IEnumerable<Models.EntityType> entities)
        {
            foreach (var enty in entities)
            {
                StructuredTypeConfig config;
                var entity = new Entity(enty, this.Options);
                this.Entities.Add(entity);
                if (this.Options.Models)
                {
                    var model = new Model(enty, entity, this.Options);
                    this.Models.Add(model);
                    var collection = new Collection(enty, model, this.Options);
                    this.Collections.Add(collection);
                    config = new StructuredTypeConfig(entity, model, collection, this.Options);
                } else {
                    config = new StructuredTypeConfig(entity, this.Options);
                }
                this.StructuredTypeConfigs.Add(config);
            }
        }
        public void AddCallables(IEnumerable<Models.Callable> callables)
        {
            foreach (var callable in callables)
            {
                this.CallablesConfigs.Add(new CallableConfig(callable));
            }
        }
        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public string Namespace => this.EdmSchema.Namespace;
        public bool HasAlias => !String.IsNullOrWhiteSpace(this.EdmSchema.Alias);
        public string Alias => this.EdmSchema.Alias;
        public override string Directory => this.EdmSchema.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public void ResolveDependencies()
        {
            this.AddDependencies(this.EnumTypeConfigs);
            this.AddDependencies(this.StructuredTypeConfigs);
            this.AddDependencies(this.Containers);
        }
        public IEnumerable<string> GetAllDirectories()
        {
            return this.Enums.Select(e => e.Directory)
                .Union(this.Entities.Select(m => m.Directory))
                .Union(this.Models.Select(m => m.Directory))
                .Union(this.StructuredTypeConfigs.Select(m => m.Directory))
                .Union(this.EnumTypeConfigs.Select(m => m.Directory))
                .Union(this.Collections.Select(m => m.Directory))
                .Union(this.Containers.SelectMany(c => c.GetAllDirectories()));
        }
        public IEnumerable<Renderable> Renderables
        {
            get
            {
                var renderables = new List<Renderable>();
                renderables.AddRange(this.Enums);
                renderables.AddRange(this.EnumTypeConfigs);
                renderables.AddRange(this.Entities);
                renderables.AddRange(this.Models);
                renderables.AddRange(this.Collections);
                renderables.AddRange(this.StructuredTypeConfigs);
                renderables.AddRange(this.Containers);
                renderables.AddRange(this.Containers.SelectMany(s => s.Renderables));
                return renderables;
            }
        }
        public object ToLiquid()
        {
            return new
            {
                Name = this.ImportedName,
            };
        }
    }
}