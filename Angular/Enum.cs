using DotLiquid;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class Enum : AngularRenderable, ILiquidizable
    {
        public Models.EnumType EdmEnumType { get; private set; }
        public Enum(Models.EnumType type, ApiOptions options) : base(options)
        {
            EdmEnumType = type;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Enumerable.Empty<string>();
        // Exports
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => Utils.ToTypescriptName(this.EdmEnumType.Name, TypeScriptElement.Enum);
        public override string Namespace => this.EdmEnumType.Namespace;
        public override string FileName => this.EdmEnumType.Name.ToLower() + ".enum";
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public IEnumerable<string> Members => this.EdmEnumType.Members.Select(m => $"{m.Name} = {m.Value}");
        public bool Flags => this.EdmEnumType.Flags;
        public object ToLiquid()
        {
            return new
            {
                Name = this.ImportedName,
                this.NamespaceQualifiedName
            };
        }
    }
}