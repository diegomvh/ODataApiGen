using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                $"{prop.Name}" + (prop.Nullable ? "?:" : ":") + $" {this.GetTypescriptType(prop.Type)};")
            );
            properties.AddRange(this.EdmStructuredType.NavigationProperties.Select(prop =>
                $"{prop.Name}" + 
                (prop.Nullable ? "?:" : ":") + 
                $" {this.GetTypescriptType(prop.Type)}" + (prop.IsCollection ? "[];" : ";"))
            );

            var imports = this.RenderImports();
            return $@"{String.Join("\n", imports)}

export {this.GetSignature()} {{
  {String.Join("\n  ", properties)}
}}"; 
        }

        public string RenderField(Property property) {
            var d = new Dictionary<string, string>() {
                {"name", $"'{property.Name}'"},
                {"type", $"'{this.GetTypescriptType(property.Type)}'"},
                {"constructor", $"{this.GetTypescriptConstructor(property.Type)}"},
                {"required", (property.Nullable ? "false" : "true")},
                {"collection", (property.IsCollection ? "true" : "false")},
            };
            if (!String.IsNullOrEmpty(property.MaxLength))
                d.Add("length", property.MaxLength);
            return $"{{{String.Join(", ", d.Select(p => $"{p.Key}: {p.Value}"))}}}";
        }

        public string RenderRelationship(NavigationProperty navigation) {
            var d = new Dictionary<string, string>() {
                {"name", $"'{navigation.Name}'"},
                {"type", $"'{this.GetTypescriptType(navigation.Type)}'"},
                {"constructor", $"{this.GetTypescriptConstructor(navigation.Type)}"},
                {"required", (navigation.Nullable ? "false" : "true")},
                {"collection", (navigation.IsCollection ? "true" : "false")},
            };
            return $"{{{String.Join(", ", d.Select(p => $"{p.Key}: {p.Value}"))}}}";
        }
        public string RenderModel() {
            var properties = this.EdmStructuredType.Properties.Select(prop =>
                $"{prop.Name}" + (prop.Nullable ? "?:" : ":") + $" {this.GetTypescriptType(prop.Type)};"
            );
            var fields = this.EdmStructuredType.Properties.Select(prop =>
                this.RenderField(prop)
            );
            var relationships = this.EdmStructuredType.NavigationProperties.Select(nav =>
                this.RenderRelationship(nav)
            );

            var parts = new List<string>();
            parts.Add(String.Join("\n", this.RenderImports()));
            parts.Add("import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';");
            parts.Add($@"export {this.GetSignature()} {{
  static schema = {(this.Base == null? $"Schema.create({{" : $"{this.Base}.schema.extend({{")}
    fields: [
      {String.Join(",\n      ", fields)}
    ],
    relationships: [
      {String.Join(",\n      ", relationships)}
    ],
    defaults: {{}}
  }});
  {String.Join("\n  ", properties)}
}}");
            if (this.EdmStructuredType is EntityType) {
                parts.Add($@"export class {this.Name}Collection extends ODataCollection<{this.Name}> {{
  static Model = {this.Name};
}}"); 
            }
            return String.Join("\n", parts);
        }

        public string GetSignature() {
            var signature = (Interface ? "interface " : "class ") + this.Name;
            if (this.Base != null)
                signature = $"{signature} extends {this.Base.Name}";
            else if (this.EdmStructuredType is ComplexType)
                signature = $"{signature} extends Model";
            else if (!Interface)
                signature = $"{signature} extends ODataModel";
            return signature;
        }

        public override string Name => this.EdmStructuredType.Name;
        public override string FileName => this.EdmStructuredType.Name.ToLower() + (Interface ? ".interface" : ".model");
        public override string Directory => this.EdmStructuredType.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public override IEnumerable<string> ImportTypes
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
        public override IEnumerable<string> ExportTypes => Interface? new string[] { this.Name } : new string[] {this.Name, $"{this.Name}Collection"};
    }
}