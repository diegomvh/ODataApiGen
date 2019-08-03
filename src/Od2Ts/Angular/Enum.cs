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
        public override string Render() {
            var members = this.EdmEnumType.Members.Select(m => $"{m.Name} = {m.Value}");
            var imports = this.RenderImports();

            return $@"{String.Join("\n", imports)}
export enum {this.Name} {{
  {String.Join(",\n  ", members)}
}}";
        }
        public override string Name => this.EdmEnumType.Name;
        public override string NameSpace => this.EdmEnumType.NameSpace;
        public override string FileName => this.EdmEnumType.Name.ToLower() + ".enum";
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public override IEnumerable<string> ImportTypes => Enumerable.Empty<string>();
        public override IEnumerable<string> ExportTypes => new string[] {this.Name};
    }
}