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
        // About File
        public override string FileName => this.Package.EndpointName.ToLower() + ".config";
        public override string Directory => this.NameSpace;

        public IEnumerable<string> Apis => this.Package.ApiConfigs
              .Select(a => $"'{a.ApiType}': {a.Name}");
        public IEnumerable<string> Enums => this.Package.EnumConfigs
              .Select(e => $"'{e.EnumType}': {e.Name}");
        public IEnumerable<string> Entities => this.Package.EntityConfigs
              .Select(e => $"'{e.EntityType}': {e.Name}");
        public IEnumerable<string> Services => this.Package.ServiceConfigs
              .Select(s => $"'{s.ServiceType}': {s.Name}");
    }
}