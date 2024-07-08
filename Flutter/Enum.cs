using DotLiquid;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Flutter
{
    public class Enum : FlutterRenderable, ILiquidizable {
        public Models.EnumType EdmEnumType {get; private set;}
        public Enum(Models.EnumType type, ApiOptions options) : base(options) {
            EdmEnumType = type;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Enumerable.Empty<string>();
        // Exports
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => Utils.ToDartName(this.EdmEnumType.Name, DartElement.Enum);
        public string EnumType => this.EdmEnumType.NamespaceQualifiedName;
        public override string FileName => this.EdmEnumType.Name.Dasherize() + ".enum";
        public override string Directory => this.EdmEnumType.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public IEnumerable<string> Members => this.EdmEnumType.Members.Select(m => $"{m.Name} = {m.Value}");
        public bool Flags => this.EdmEnumType.Flags;
        public object ToLiquid()
        {
            return new { 
                Name = this.ImportedName,
                EnumType = this.EnumType
            };
        }
    }
}