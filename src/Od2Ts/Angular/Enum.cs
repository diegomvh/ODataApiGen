using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Od2Ts.Angular {
    public class Enum : AngularRenderable {
        public Models.EnumType EdmEnumType {get; private set;}
        public Enum(Models.EnumType type) {
            EdmEnumType = type;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Enumerable.Empty<string>();
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] {this.Name};
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.EdmEnumType.Name;
        public override string NameSpace => this.EdmEnumType.NameSpace;
        public override string FileName => this.EdmEnumType.Name.ToLower() + ".enum";
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public IEnumerable<string> Members => this.EdmEnumType.Members.Select(m => $"{m.Name} = {m.Value}");
        public string IsFlags => this.EdmEnumType.IsFlags.ToString().ToLower();
        public override string Render() {
            return "";
        }
    }
}