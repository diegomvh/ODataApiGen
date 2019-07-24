using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public abstract class Model : AngularRenderable
    {
        public StructuredType EdmStructuredType { get; private set; }

        public Model Base { get; private set; }

        public Model(StructuredType type)
        {
            EdmStructuredType = type;
        }

        public void SetBase(Model b)
        {
            this.Base = b;
        }

        public override string Name => this.EdmStructuredType.Name;
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
        protected string RenderProperty(Property prop)
        {
            return $"{prop.Name}" +
                (prop.IsNullable ? "?:" : ":") +
                $" {this.GetTypescriptType(prop.Type)}" +
                (prop.IsCollection ? "[];" : ";");
        }
    }

    public class ModelClass : Model
    {
        public ModelClass(StructuredType type) : base(type)
        {
        }
        public string GetModelType(string type)
        {
            if (String.IsNullOrWhiteSpace(type))
                return "any";
            switch (type)
            {
                case "Edm.String":
                case "Edm.Duration":
                case "Edm.Guid":
                case "Edm.Binary":
                    return "String";
                case "Edm.Int16":
                case "Edm.Int32":
                case "Edm.Int64":
                case "Edm.Double":
                case "Edm.Decimal":
                case "Edm.Single":
                case "Edm.Byte":
                    return "Number";
                case "Edm.Boolean":
                    return "Boolean";
                case "Edm.DateTimeOffset":
                    return "Date";
                default:
                    {
                        return type.Contains(".") && !type.StartsWith("Edm") ? type : "Object";
                    }
            }
        }
        public IEnumerable<string> RenderModelMethods(NavigationProperty nav)
        {
            var type = this.GetTypescriptType(nav.Type);
            var name = nav.Name[0].ToString().ToUpper() + nav.Name.Substring(1);
            var methodRelationName = $"get{name}";
            var baseMethodRelationName = nav.IsCollection ? $"relatedCollection" : $"relatedModel";
            var returnType = (nav.IsCollection) ?
                $"Collection<{type}>" :
                $"{type}";
            // Navigation
            var methods = new List<string>() {$@"public {methodRelationName}(): {returnType} {{
    return this.{baseMethodRelationName}('{nav.Name}') as {returnType};
  }}"};
            return methods;
        }
        public IEnumerable<string> RenderODataModelMethods(NavigationProperty nav)
        {
            var type = this.GetTypescriptType(nav.Type);
            var name = nav.Name[0].ToString().ToUpper() + nav.Name.Substring(1);
            var methodRelationName = $"get{name}";
            var methodCreateName = nav.IsCollection ? $"add{type}To{name}" : $"set{type}As{name}";
            var methodDeleteName = nav.IsCollection ? $"remove{type}From{name}" : $"unset{type}As{name}";
            var baseMethodRelationName = nav.IsCollection ? $"relatedODataCollection" : $"relatedODataModel";
            var baseMethodCreateName = nav.IsCollection ? $"createODataCollectionRef" : $"createODataModelRef";
            var baseMethodDeleteName = nav.IsCollection ? $"deleteODataCollectionRef" : $"deleteODataModelRef";
            var returnType = (nav.IsCollection) ?
                $"ODataCollection<{type}>" :
                $"{type}";
            // Navigation
            var methods = new List<string>() {$@"public {methodRelationName}(): {returnType} {{
    return this.{baseMethodRelationName}('{nav.Name}') as {returnType};
  }}"};
            // Link
            methods.Add($@"public {methodCreateName}(target: ODataQueryBase, options?) {{
    return this.{baseMethodCreateName}('{nav.Name}', target, options);
  }}");
            // Unlink
            methods.Add($@"public {methodDeleteName}(target: ODataQueryBase, options?) {{
    return this.{baseMethodDeleteName}('{nav.Name}', target, options);
  }}");
            return methods;
        }
        public string RenderField(Property property)
        {
            var d = new Dictionary<string, string>() {
                {"name", $"'{property.Name}'"},
                {"required", (property.IsNullable ? "false" : "true")}
            };
            var type = this.GetModelType(property.Type);
            if (!property.IsEdmType && property.IsCollection)
                type = $"{type}Collection";
            d.Add("type", $"'{type}'");
            if (!String.IsNullOrEmpty(property.MaxLength) && property.MaxLength.ToLower() != "max")
                d.Add("length", property.MaxLength);
            return $"{{{String.Join(", ", d.Select(p => $"{p.Key}: {p.Value}"))}}}";
        }
        public string GetSignature()
        {
            var signature = $"class {this.Name}";
            if (this.Base != null)
                signature = $"{signature} extends {this.Base.Name}";
            else if (this.EdmStructuredType is ComplexType)
                signature = $"{signature} extends Model";
            else
                signature = $"{signature} extends ODataModel";
            return signature;
        }

        public override string Render()
        {
            var properties = this.EdmStructuredType.Properties
                .Select(prop => this.RenderProperty(prop));
            var methods = this.EdmStructuredType.NavigationProperties
                .SelectMany(nav => 
                    (EdmStructuredType is ComplexType) ? 
                    this.RenderModelMethods(nav) : 
                    this.RenderODataModelMethods(nav));

            var keys = this.EdmStructuredType.KeyNames.Select(k => $"'{k}'");
            var fields = this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => this.RenderField(prop)
            );

            var imports = this.RenderImports();
            return $@"{String.Join("\n", imports)}
import {{ Schema, Model, ODataQueryBase, ODataModel, ODataCollection }} from 'angular-odata';

export {this.GetSignature()} {{
  static type = '{this.GetModelType(this.EdmStructuredType.Type)}';
  static schema = {(this.Base == null ? $"Schema.create({{" : $"{this.Base.Name}.schema.extend({{")}
    keys: [
        {String.Join(", ", keys)}
    ],
    fields: [
      {String.Join(",\n      ", fields)}
    ],
    defaults: {{}}
  }});
  {String.Join("\n  ", properties)}

  {String.Join("\n  ", methods)}
}}";
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
    }

    public class ModelInterface : Model
    {
        public ModelInterface(StructuredType type) : base(type)
        {
        }
        public string GetSignature()
        {
            var signature = $"interface {this.Name}";
            if (this.Base != null)
                signature = $"{signature} extends {this.Base.Name}";
            return signature;
        }

        public override string Render()
        {
            var properties = this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop =>
                    this.RenderProperty(prop)
                );

            var imports = this.RenderImports();
            return $@"{String.Join("\n", imports)}

export {this.GetSignature()} {{
  {String.Join("\n  ", properties)}
}}";
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".interface";
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
    }
}