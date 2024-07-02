using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class Api : AngularRenderable {
        public Angular.Package Package {get; private set;}
        public Api(Package package, ApiOptions options) : base(options){
            this.Package = package;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Package.Schemas.SelectMany(m => m.ImportTypes);
        // Exports
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.Name + "Api";
        public override string Namespace => "";
        // About File
        public override string FileName => this.Package.Name.ToLower() + ".api";
        public override string Directory => this.Namespace;
        public IEnumerable<EnumTypeConfig> EnumTypeConfigs { get; set; }
        public IEnumerable<StructuredTypeConfig> StructuredTypeConfigs { get; set; }
        public IEnumerable<EntitySetConfig> EntitySetConfigs { get; set; }
        public IEnumerable<CallableConfig> CallableConfigs { get; set; }
        public IEnumerable<Models.EnumType> EnumTypes => this.EnumTypeConfigs.Select(e => e.Enum.EdmEnumType);
        public IEnumerable<Models.ComplexType> ComplexTypes => this.StructuredTypeConfigs.Select(e => e.Entity.EdmStructuredType).OfType<Models.ComplexType>();
        public IEnumerable<Models.EntityType> EntityTypes => this.StructuredTypeConfigs.Select(e => e.Entity.EdmStructuredType).OfType<Models.EntityType>();
        public IEnumerable<Models.EntitySet> EntitySets => this.EntitySetConfigs.Select(e => e.Service).OfType<ServiceEntitySet>().Select(s => s.EdmEntitySet);
        public IEnumerable<Models.Singleton> Singletons => this.EntitySetConfigs.Select(e => e.Service).OfType<ServiceSingleton>().Select(s => s.EdmSingleton);
        public IEnumerable<Models.Function> Functions => this.CallableConfigs.Select(e => e.Callable).OfType<Models.Function>();
        public IEnumerable<Models.Action> Actions => this.CallableConfigs.Select(e => e.Callable).OfType<Models.Action>();
    }
}