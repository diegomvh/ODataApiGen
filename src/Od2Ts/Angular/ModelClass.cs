using System.Collections.Generic;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ModelSchemaField : SchemaField
    {
        public ModelSchemaField(Property property, AngularRenderable type) : base(property, type)
        {
        }
    }

    public class ModelProperty : DotLiquid.ILiquidizable
    {
        private Models.Property Value { get; set; }
        public ModelProperty(Od2Ts.Models.Property prop)
        {
            this.Value = prop;
        }
        public IEnumerable<string> Name { get; set; }

        public string Type => AngularRenderable.GetTypescriptType(Value.Type);
        public object ToLiquid()
        {
            return new
            {
                Name = Value.Name + (Value.IsNullable ? "?" : ""),
                Type = this.Type + (Value.IsCollection ? Value.IsEdmType ? "[]" : "Collection" : "")
            };
        }
    }
    public class ModelClass : Model, DotLiquid.ILiquidizable
    {
        public ModelClass(StructuredType type) : base(type)
        {
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        protected string RenderProperty(Models.Property prop)
        {
            var field = $"{prop.Name}" +
                (prop.IsNullable ? "?:" : ":") +
                $" {AngularRenderable.GetTypescriptType(prop.Type)}";
            if (prop.IsEdmType) {
                field = $"{field}" + (prop.IsCollection ? "[];" : ";");
            } else {
                field = $"{field}" + (prop.IsCollection ? "Collection;" : ";");
            }
            return field;
        }

        public IEnumerable<string> RenderModelMethods(NavigationProperty nav)
        {
            var type = AngularRenderable.GetTypescriptType(nav.Type);
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
            var type = AngularRenderable.GetTypescriptType(nav.Type);
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
        public IEnumerable<SchemaKey> SchemaKeys => this.EdmStructuredType.Keys.Select(prop => new SchemaKey(prop));
        public IEnumerable<ModelSchemaField> SchemaFields => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => {
                    var propType = (prop.IsCollection) ? $"{prop.Type}Collection" : prop.Type;
                    var type = this.Dependencies.FirstOrDefault(dep => dep.Type == propType);
                    return new ModelSchemaField(prop, type as AngularRenderable); 
                    });
        public IEnumerable<Angular.ModelProperty> Properties => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => new Angular.ModelProperty(prop));
        public object ToLiquid()
        {
            return new {
                Name = this.Name
            };
        }
    }
}