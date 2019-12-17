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
        public override IEnumerable<string> ImportTypes => Package.Models.SelectMany(m => m.ImportTypes);
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] {this.Name};
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.EndpointName + "Config";
        public override string NameSpace => "";
        public override string FileName => this.Package.EndpointName.ToLower() + ".config";

        public IEnumerable<string> Enums => this.Package.Enums
              .Select(e => $"'{e.EnumType}': {e.Name}");
        public override string Directory => this.NameSpace;
        public IEnumerable<string> Models => this.Package.Models
              .Where(m => m is Model)
              .Select(model => $"'{model.EntityType}': {model.Name}");
        public IEnumerable<string> Collections => this.Package.Collections
              .Select(col => $"'{col.EntityType}': {col.Name}");
        public IEnumerable<string> Schemas => this.Package.Schemas
              .Select(entity => $"'{entity.EntityType}': {entity.Name}");
    }
}