using ODataApiGen.Abstracts;

namespace ODataApiGen.Flutter
{
    public class Index : FlutterRenderable
    {
        public Flutter.Package Package {get; private set;}
        public Index(Flutter.Package package, ApiOptions options) : base(options)
        {
            this.Package = package;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Enumerable.Empty<string>();
        // Exports
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.Name;
        public override string FileName => "index";
        public override string Directory => "";
        public IEnumerable<string> Exports =>this.GetImportRecords().Select(import => $"export * from './{import.From}'");
    }
}
