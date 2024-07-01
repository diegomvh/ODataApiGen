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
        public IEnumerable<Angular.EnumTypeConfig> EnumTypeConfigs { get; set; }
        public IEnumerable<Angular.StructuredTypeConfig> StructuredTypeConfigs { get; set; }
        public IEnumerable<Angular.EntitySetConfig> EntitySetConfigs { get; set; }
    }
}