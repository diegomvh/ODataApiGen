using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular {
    public class Config : AngularRenderable {
        public Angular.AngularPackage Package {get; private set;}
        public Config(AngularPackage package) {
            this.Package = package;
        }
        public override string Render() {
            var imports = this.RenderImports();
            var models = this.Package.Models.Select(model => $"'{model.EdmStructuredType.Type}': {model.Name}");
            var collections = this.Package.Models.Where(m => ! (m.EdmStructuredType is ComplexType)).Select(model => $"{model.Name}Collection");
            return $@"{String.Join("\n", imports)}
export const {this.Name} = {{
  baseUrl: '{this.Package.MetadataPath.TrimEnd("$metadata".ToCharArray())}',
  metadataUrl: '{this.Package.MetadataPath}',
  withCredentials: {this.Package.Secure.ToString().ToLower()},
  creation: new Date('{DateTime.Now.ToString("o")}'),
  version: '{this.Package.Version}',
  models: {{
    {String.Join(",\n    ", models)}
  }},
  collections: [
    {String.Join(",\n    ", collections)}
  ]
}}";
        }
        public override string Name => this.Package.EndpointName + "Config";
        public override string FileName => this.Package.EndpointName.ToLower() + ".config";
        public override string Directory => "";
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