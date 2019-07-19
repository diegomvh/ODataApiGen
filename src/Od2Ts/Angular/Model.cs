using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Abstracts;
using Od2Ts.Models;

namespace Od2Ts.Angular {
    public class Model : Renderable {
        public StructuredType EdmStructuredType {get; private set;}

        public bool Interface {get; private set;}
        public Model Base {get; private set;}

        public Model(StructuredType type, bool inter) {
            EdmStructuredType = type;
            Interface = inter;
        }

        public void SetBase(Model b) {
            this.Base = b;
        }

        public override string Render() {
            return Interface ?
                RenderInterface():
                RenderModel();
        }

        public string RenderInterface() {
            var properties = new List<string>();
            properties.AddRange(this.EdmStructuredType.Properties.Select(prop =>
                $"{prop.Name}" + (prop.IsRequired ? ":" : "?:") + $" {this.GetTypescriptType(prop.Type)};")
            );
            properties.AddRange(this.EdmStructuredType.NavigationProperties.Select(prop =>
                $"{prop.Name}" + 
                (prop.IsRequired ? ":" : "?:") + 
                $" {this.GetTypescriptType(prop.Type)}" + (prop.IsCollection ? "[];" : ";"))
            );

            var imports = this.RenderImports();
            return $@"{String.Join("\n", imports)}

export {this.GetSignature()} {{
  {String.Join("\n  ", properties)}
}}"; 
        }
        public string RenderModel() {
            var properties = this.EdmStructuredType.Properties.Select(prop =>
                $"{prop.Name}" + (prop.IsRequired ? ":" : "?:") + $" {this.GetTypescriptType(prop.Type)};"
            );
            var fields = this.EdmStructuredType.Properties.Select(prop =>
                $"{{name: '{prop.Name}', type: '{this.GetTypescriptType(prop.Type)}', required: " + (prop.IsRequired ? "true" : "false") + $", length: {prop.Length}, collection: " + (prop.IsCollection ? "true" : "false") + $"}}"
            );
            var relations = this.EdmStructuredType.NavigationProperties.Select(prop =>
                $"{{name: '{prop.Name}', type: '{this.GetTypescriptType(prop.Type)}', required: " + (prop.IsRequired ? "true" : "false") + $", length: {prop.Length}, collection: " + (prop.IsCollection ? "true" : "false") + $"}}"
            );

            var imports = this.RenderImports();
            return $@"{String.Join("\n", imports)}
import {{ ODataModel, Property }} from 'angular-odata';

export {this.GetSignature()} {{
  {String.Join("\n  ", properties)}
  protected options = {{
    fields: [
      {String.Join(",\n      ", fields)}
    ],
    relations: [
      {String.Join(",\n      ", relations)}
    ],
  }}
}}"; 
        }

        public string GetSignature() {
            var signature = (Interface ? "interface " : "class ") + this.Name;
            if (this.Base != null)
                signature = $"{signature} extends {this.Base.Name}";
            else if (!Interface)
                signature = $"{signature} extends ODataModel";
            return signature;
        }

        public override string Name => this.EdmStructuredType.Name;
        public override string FileName => this.EdmStructuredType.Name.ToLower() + (Interface ? ".interface" : ".model");
        public override string Directory => this.EdmStructuredType.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public override IEnumerable<string> Types
        {
            get
            {
                var types = this.EdmStructuredType.NavigationProperties
                    .Select(a => a.Type)
                    .Where(a => a != this.EdmStructuredType.Type)
                    .ToList();
                /*For Not-EDM types (e.g. enums with namespaces, complex types*/
                types.AddRange(this.EdmStructuredType.Properties
                    .Where(a => !a.IsEdmType)
                    .Select(a => a.Type));
                if (this.Base != null)
                    types.Add(this.Base.EdmStructuredType.Type);
                return types.Distinct();
            }
        }

    }
}