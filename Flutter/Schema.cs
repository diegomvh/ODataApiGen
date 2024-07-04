using ODataApiGen.Abstracts;

namespace ODataApiGen.Flutter
{
    public class Schema : FlutterRenderable, DotLiquid.ILiquidizable
    {
        public Models.Schema EdmSchema { get; private set; }
        public override string FileName => this.EdmSchema.Namespace.Split('.').Last().ToLower() + ".schema";
        //TODO: Create nice schema names
        public override string Name => Utils.ToDartName(this.EdmSchema.Namespace.Split('.').Last(), DartElement.Class) + "Schema";
        public ICollection<Flutter.Enum> Enums { get; } = new List<Flutter.Enum>();
        public ICollection<Flutter.EnumTypeConfig> EnumConfigs { get; } = new List<Flutter.EnumTypeConfig>();
        public ICollection<Flutter.Entity> Entities { get; } = new List<Flutter.Entity>();
        public ICollection<Flutter.Model> Models { get; } = new List<Flutter.Model>();
        public ICollection<Flutter.Collection> Collections { get; } = new List<Flutter.Collection>();
        public ICollection<Flutter.StructuredTypeConfig> EntityConfigs { get; } = new List<Flutter.StructuredTypeConfig>();
        public ICollection<Flutter.CallableConfig> CallablesConfigs { get; } = new List<Flutter.CallableConfig>();
        public ICollection<Flutter.Container> Containers { get; } = new List<Flutter.Container>();
        public Schema(Models.Schema schema, ApiOptions options) : base(options)
        {
            this.EdmSchema = schema;
            this.AddEnums(schema.EnumTypes);
            this.AddComplexes(schema.ComplexTypes);
            this.AddEntities(schema.EntityTypes);
            this.AddCallables(schema.Functions);
            this.AddCallables(schema.Actions);
            foreach (var container in schema.EntityContainers)
            {
                this.Containers.Add(new Flutter.Container(container, options));
            }
        }
        public void AddEnums(IEnumerable<Models.EnumType> enums)
        {
            foreach (var e in enums)
            {
                var enu = new Flutter.Enum(e, this.Options);
                this.Enums.Add(enu);
                var config = new Flutter.EnumTypeConfig(enu, this.Options);
                this.EnumConfigs.Add(config);
            }
        }
        public void AddComplexes(IEnumerable<Models.ComplexType> complexes)
        {
            foreach (var cmplx in complexes)
            {
                Flutter.StructuredTypeConfig config;
                var entity = new Flutter.Entity(cmplx, this.Options);
                this.Entities.Add(entity);
                if (this.Options.Models)
                {
                    var model = new Flutter.Model(cmplx, entity, this.Options);
                    this.Models.Add(model);
                    var collection = new Flutter.Collection(cmplx, model, this.Options);
                    this.Collections.Add(collection);
                    config = new Flutter.StructuredTypeConfig(entity, model, collection, this.Options);
                } else {
                    config = new Flutter.StructuredTypeConfig(entity, this.Options);
                }
                this.EntityConfigs.Add(config);
            }
        }
        public void AddEntities(IEnumerable<Models.EntityType> entities)
        {
            foreach (var enty in entities)
            {
                Flutter.StructuredTypeConfig config;
                var entity = new Flutter.Entity(enty, this.Options);
                this.Entities.Add(entity);
                if (this.Options.Models)
                {
                    var model = new Flutter.Model(enty, entity, this.Options);
                    this.Models.Add(model);
                    var collection = new Flutter.Collection(enty, model, this.Options);
                    this.Collections.Add(collection);
                    config = new Flutter.StructuredTypeConfig(entity, model, collection, this.Options);
                } else {
                    config = new Flutter.StructuredTypeConfig(entity, this.Options);
                }
                this.EntityConfigs.Add(config);
            }
        }
        public void AddCallables(IEnumerable<Models.Callable> callables)
        {
            foreach (var callable in callables)
            {
                this.CallablesConfigs.Add(new Flutter.CallableConfig(callable));
            }
        }
        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public bool HasAlias => !String.IsNullOrWhiteSpace(this.EdmSchema.Alias);
        public string Alias => this.EdmSchema.Alias;
        public override string Directory => this.EdmSchema.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public void ResolveDependencies()
        {
            this.AddDependencies(this.EnumConfigs);
            this.AddDependencies(this.EntityConfigs);
            this.AddDependencies(this.Containers);
        }
        public IEnumerable<string> GetAllDirectories()
        {
            return this.Enums.Select(e => e.Directory)
                .Union(this.Entities.Select(m => m.Directory))
                .Union(this.Models.Select(m => m.Directory))
                .Union(this.EntityConfigs.Select(m => m.Directory))
                .Union(this.EnumConfigs.Select(m => m.Directory))
                .Union(this.Collections.Select(m => m.Directory))
                .Union(this.Containers.SelectMany(c => c.GetAllDirectories()));
        }
        public IEnumerable<Renderable> Renderables
        {
            get
            {
                var renderables = new List<Renderable>();
                renderables.AddRange(this.Enums);
                renderables.AddRange(this.EnumConfigs);
                renderables.AddRange(this.Entities);
                renderables.AddRange(this.Models);
                renderables.AddRange(this.Collections);
                renderables.AddRange(this.EntityConfigs);
                renderables.AddRange(this.Containers);
                renderables.AddRange(this.Containers.SelectMany(s => s.Renderables));
                return renderables;
            }
        }
        public object ToLiquid()
        {
            return new
            {
                Name = this.ImportedName
            };
        }
    }
}