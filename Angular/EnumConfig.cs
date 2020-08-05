using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class EnumConfig: AngularRenderable, DotLiquid.ILiquidizable 
    {
        public Angular.Enum Enum {get; private set;}
        public EnumConfig(Angular.Enum enu, ApiOptions options) : base(options) {
            this.Enum = enu;
        }
        public override string FileName => this.Enum.FileName + ".config";
        public override string Name => this.Enum.Name + "Config";
        public string EnumType => this.Enum.EdmEnumType.FullName;
        public string EdmEnumName => this.Enum.EdmEnumType.Name;
        public string EnumName => this.Enum.Name;

        public string EnumAnnotations {
            get {
                return JsonConvert.SerializeObject(this.Enum.EdmEnumType.Annotations.Select(annot => annot.ToDictionary()));
            }
        }

        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { this.EnumType };
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Namespace => this.Enum.EdmEnumType.Namespace;
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public bool Flags => this.Enum.EdmEnumType.Flags; 

        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                EnumName = this.EnumName
            };
        }
    }
}