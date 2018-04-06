using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Abstracts;
using Od2Ts.Interfaces;

namespace Od2Ts.Angular {
    public class Enum : Renderable, IHasImports {
        public Models.EnumType EdmEnumType {get; private set;}
        public Enum(Models.EnumType type) {
            EdmEnumType = type;
        }
        public override string Render() {
            var members = this.EdmEnumType.Members.Select(m => $"{m.Name} = {m.Value}");
            var imports = this.RenderImports(this);

            return $@"{String.Join("\n", imports)}
            export enum {this.EdmEnumType.Name} {{
                {String.Join(",\n", members)}
            }}";
        }

        public IEnumerable<Import> Imports
        {
            get
            {
                return Enumerable.Empty<Import>();
            }
        }
        public Uri Uri { get { return this.BuildUri(this.EdmEnumType.NameSpace, this.EdmEnumType.Name); } }

        public override string Name => this.EdmEnumType.Name;

        public override string NameSpace => this.EdmEnumType.NameSpace;
    }
}