using System;
using System.Collections.Generic;
using System.Linq;

namespace Od2Ts.Angular {
    public class Config : AngularRenderable {
        public Angular.Package Package {get; private set;}
        public Config(Package package) {
            this.Package = package;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Package.Models.SelectMany(m => m.ImportTypes);
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] {this.Name};
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.EndpointName + "Config";
        public override string NameSpace => "";
        public override string FileName => this.Package.EndpointName.ToLower() + ".config";
        public override string Directory => this.NameSpace;
        public IEnumerable<string> Types => this.Package.Models
              .Where(m => m is ModelClass)
              .Select(model => $"'{model.Type}': {model.Name}")
          .Union(this.Package.Collections
              .Select(col => $"'{col.Type}': {col.Name}"));

        public override string Render() {
          return "";
        }
    }
}