using ODataApiGen.Abstracts;

namespace ODataApiGen.Flutter
{
    public class ApiConfig : FlutterRenderable {
        public Flutter.Package Package {get; private set;}
        public ApiConfig(Package package, ApiOptions options) : base(options){
            this.Package = package;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Package.Schemas.SelectMany(m => m.ImportTypes);
        // Exports
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.Name + "Config";
        public override string Namespace => "";
        // About File
        public override string FileName => this.Package.Name.ToLower() + ".config";
        public override string Directory => this.Namespace;
    }
}