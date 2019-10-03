using System;
using System.Collections.Generic;
using System.Linq;

namespace Od2Ts.Angular {
    public class Config : AngularRenderable {
        public Angular.Package Package {get; private set;}
        public Config(Package package) {
            this.Package = package;
        }
        public override string Render() {
            var imports = this.RenderImports();
            var enums = this.Package.Enums.Select(enu => $"'{enu.EdmEnumType.Type}': {enu.Name}");
            var models = this.Package.Models
              .Where(m => m is ModelClass)
              .Select(model => model.Name);
            var collections = this.Package.Collections
              .Select(col => col.Name);
            return $@"{String.Join("\n", imports)}
export const {this.Name} = {{
  baseUrl: '{this.Package.MetadataPath.TrimEnd("$metadata".ToCharArray())}',
  metadataUrl: '{this.Package.MetadataPath}',
  withCredentials: {this.Package.Secure.ToString().ToLower()},
  batch: {this.Package.BatchQueries.ToString().ToLower()},
  creation: new Date('{DateTime.Now.ToString("o")}'),
  version: '{this.Package.Version}',
  enums: {{
    {String.Join(",\n    ", enums)}
  }},
  models: [
    {String.Join(",\n    ", models)}
  ],
  collections: [
    {String.Join(",\n    ", collections)}
  ]
}}";
        }
        public override string Name => this.Package.EndpointName + "Config";
        public override string NameSpace => "";
        public override string FileName => this.Package.EndpointName.ToLower() + ".config";
        public override string Directory => this.NameSpace;
        public override IEnumerable<string> ImportTypes 
        {
            get { 
                var ns = new List<String>();
                ns.AddRange(Package.Models.SelectMany(m => m.ImportTypes));
                return ns;
            }
        }
        public override IEnumerable<string> ExportTypes => new string[] {this.Name};
    }
}