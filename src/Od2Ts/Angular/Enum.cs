using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Od2Ts.Angular {
    public class Enum : AngularRenderable {
        public Enum(Models.EnumType type) {
            EdmEnumType = type;
        }
        public override string Render() {
            return "";
        }
        public Models.EnumType EdmEnumType {get; private set;}
        public override string Name => this.EdmEnumType.Name;
        public IEnumerable<string> Members => this.EdmEnumType.Members.Select(m => $"{m.Name} = {m.Value}");
        public override string NameSpace => this.EdmEnumType.NameSpace;
        public override string FileName => this.EdmEnumType.Name.ToLower() + ".enum";
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public override IEnumerable<string> ImportTypes => Enumerable.Empty<string>();
        public override IEnumerable<string> ExportTypes => new string[] {this.Name};
    }
}