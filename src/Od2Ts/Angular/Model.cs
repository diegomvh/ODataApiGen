using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Angular {
    public class Model : Renderable {
        public Angular.Service Service {get; private set;}
        public Model Base {get; private set;}
        public Models.EntitySet EdmEntitySet { get; private set; }
        public Model(Models.EntitySet type)
        {
            EdmEntitySet = type;
        }

        public void SetService(Angular.Service service) {
            this.Service = service;
        }

        public void SetBase(Model b) {
            this.Base = b;
        }

        public override string Render() {
            var properties = new List<string>();
            properties.AddRange(this.Service.Interface.EdmStructuredType.Properties.Select(prop =>
                $"{{name: '{prop.Name}', type: '{this.GetTypescriptType(prop.Type)}', required: " + (prop.IsRequired ? "true" : "false") + $", length: {prop.Length}, collection: " + (prop.IsCollection ? "true" : "false") + $"}}")
            );
            properties.AddRange(this.Service.Interface.EdmStructuredType.NavigationProperties.Select(prop =>
                $"{{name: '{prop.Name}', type: '{this.GetTypescriptType(prop.Type)}', required: " + (prop.IsRequired ? "true" : "false") + $", length: {prop.Length}, collection: " + (prop.IsCollection ? "true" : "false") + $"}}")
            );

            var imports = this.RenderImports();
            return $@"{String.Join("\n", imports)}
import {{ ODataModel, Property }} from 'angular-odata';

export {this.GetModelSignature()} {{
  protected properties() : Property[] {{
    return [
      {String.Join(",\n      ", properties)}
    ];
  }}
}}"; 
        }

        public string GetModelSignature() {
            return (this.Base != null) ?
                $"class {this.Name} extends {this.Base.Name}" :
                $"class {this.Name} extends ODataModel<{this.GetTypescriptType(this.EdmEntitySet.EntityType)}>";
        }

        public override string Name => this.GetTypescriptType(this.EdmEntitySet.EntityType) + "Model";
        public override string FileName => this.GetTypescriptType(this.EdmEntitySet.EntityType).ToLower() + ".model";
        public override string Directory => String.Join(Path.DirectorySeparatorChar, this.EdmEntitySet.EntityType.Split('.').Reverse().Skip(1).Reverse());

        public override IEnumerable<string> Types
        {
            get
            {
                var types = new List<string>() { this.EdmEntitySet.EntityType };
                if (this.Base != null)
                    types.Add(this.Base.Type);
                return types;
            }
        }
        public string Type { get { return $"{this.EdmEntitySet.EntityType}.{this.Name}"; } }
    }
}