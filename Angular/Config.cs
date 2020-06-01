using System;
using System.Collections.Generic;
using System.Linq;

namespace ODataApiGen.Angular {
    public class Config : AngularRenderable {
        public Angular.Package Package {get; private set;}
        public Config(Package package) {
            this.Package = package;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Package.Schemas.SelectMany(m => m.ImportTypes);
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] {this.Name};
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.Name + "Config";
        public override string Namespace => "";
        // About File
        public override string FileName => this.Package.Name.ToLower() + ".config";
        public override string Directory => this.Namespace;
    }
}