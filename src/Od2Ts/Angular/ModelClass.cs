using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ModelClass : Model
    {
        public ModelClass(StructuredType type) : base(type)
        {
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
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
        protected string RenderProperty(Models.Property prop)
        {
            var field = $"{prop.Name}" +
                (prop.IsNullable ? "?:" : ":") +
                $" {this.GetTypescriptType(prop.Type)}";
            if (prop.IsEdmType) {
                field = $"{field}" + (prop.IsCollection ? "[];" : ";");
            } else {
                field = $"{field}" + (prop.IsCollection ? "Collection;" : ";");
            }
            return field;
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
        public string RenderKey(PropertyRef propertyRef)
        {
            var d = new Dictionary<string, string>() {
                {"name", $"'{propertyRef.Name}'"}
            };
            if (!String.IsNullOrWhiteSpace(propertyRef.Alias)) {
                d.Add("name", $"'{propertyRef.Alias}'");
                d.Add("resolve", $"(model) => model.{propertyRef.Name.Replace('/', '.')}");
            }
            return $"{{{String.Join(", ", d.Select(p => $"{p.Key}: {p.Value}"))}}}";
        }
        public string RenderField(Models.Property property)
        {
            var d = new Dictionary<string, string>() {
                {"name", $"'{property.Name}'"}
            };
            var propType = property.Type;
            if (property.IsCollection)
                propType = $"{propType}Collection";
            var type = this.Dependencies.FirstOrDefault(dep => dep.Type == propType);
            if (type == null) {
                // Is Edm
                d.Add("type", $"'{this.GetModelType(property.Type)}'");
                if (!property.IsNullable)
                    d.Add("required", "true");
                if (!String.IsNullOrEmpty(property.MaxLength) && property.MaxLength.ToLower() != "max")
                    d.Add("length", property.MaxLength);
                if (property.IsCollection)
                    d.Add("collection", "true");
            } else {
                d.Add("type", $"'{type.Type}'");
                if (!(type is Enum))
                    d.Add("ctor", "true");
                if (!property.IsNullable)
                    d.Add("required", "true");
                if (property is NavigationProperty) {
                    d.Add("navigation", "true");
                    var nav = property as NavigationProperty;
                    if (!String.IsNullOrEmpty(nav.ReferentialConstraint))
                        d.Add("field", $"'{nav.ReferentialConstraint}'");
                    if (!String.IsNullOrEmpty(nav.ReferencedProperty))
                        d.Add("ref", $"'{nav.ReferencedProperty}'");
                }
                if (property.IsCollection)
                    d.Add("collection", "true");
            }
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
            var keys = this.EdmStructuredType.Keys
                .Select(prop => this.RenderKey(prop));
            var properties = this.EdmStructuredType.Properties
                .Select(prop => this.RenderProperty(prop)).ToList();
            properties.AddRange(this.EdmStructuredType.NavigationProperties
                .Select(prop => this.RenderProperty(prop)));
            var methods = this.EdmStructuredType.NavigationProperties
                .SelectMany(nav => 
                    (EdmStructuredType is ComplexType) ? 
                    this.RenderModelMethods(nav) : 
                    this.RenderODataModelMethods(nav));
            // Sin metodos para probar
            methods = Enumerable.Empty<string>();
            var fields = this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => this.RenderField(prop)
            );

            var imports = this.RenderImports();
            return $@"{String.Join("\n", imports)}
import {{ Schema, Model, ODataModel, ODataCollection, PlainObject }} from 'angular-odata';

export {this.GetSignature()} {{
  static set = '{(this.Service != null ? this.Service.EdmEntitySet.EntitySetName : "")}';
  static type = '{this.Type}';
  static schema = {(this.Base == null ? $"Schema.create({{" : $"{this.Base.Name}.schema.extend({{")}
    keys: [
      {String.Join(",\n      ", keys)}
    ],
    fields: [
      {String.Join(",\n      ", fields)}
    ]
  }});
  {String.Join("\n  ", properties)}

  {String.Join("\n  ", methods)}
}}";
        }
    }
}