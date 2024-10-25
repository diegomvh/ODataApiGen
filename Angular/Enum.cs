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
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => Utils.ToTypescriptName(this.EdmEnumType.Name, TypeScriptElement.Enum);
        public override string FileName => this.EdmEnumType.Name.Dasherize() + ".enum";
        public override string Directory => this.EdmEnumType.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public string FullName => this.EdmEnumType.NamespaceQualifiedName;
        public string TypeName => this.Name + "EnumType";
        public IEnumerable<string> Members => this.EdmEnumType.Members.Select(m => $"{m.Name} = {m.Value}");
        public bool Flags => this.EdmEnumType.Flags;
        public object ToLiquid()
        {
            return new
            {
                Name = this.ImportedName,
            };
        }
    }
}