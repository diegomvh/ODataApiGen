using System.Collections.Generic;
using System.Linq;
using System.IO;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
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
                Type = this.Type + (Value.IsCollection ? Value.IsEdmType ? "[]" : "Collection" : ""),
            };
        }
    }
    public class Model : AngularRenderable, DotLiquid.ILiquidizable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Model(StructuredType type)
        {
            EdmStructuredType = type;
        }
        public Model Base { get; private set; }
        public Angular.Entity Entity {get; private set;}
        public Angular.Collection Collection {get; private set;}
        public Angular.Service Service {get; private set;}

        public void SetBase(Model b)
        {
            this.Base = b;
        }
        public void SetCollection(Collection collection)
        {
            this.Collection = collection;
        }
        public void SetService(Service service)
        {
            this.Service = service;
        }

        // Imports
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var types = this.EdmStructuredType.NavigationProperties
                    .Select(a => a.Type)
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
        public override string Name => this.EdmStructuredType.Name;
        public string EntityType => this.EdmStructuredType.Type;
        public override string NameSpace => this.EdmStructuredType.NameSpace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override IEnumerable<string> ExportTypes => new string[] { this.Name, this.SchemaName };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public string SchemaName => this.EdmStructuredType.Name + "Schema";
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
                $"ODataCollection<{type}>" :
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
        public IEnumerable<SchemaField> SchemaFields => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => {
                    var propType = (prop.IsCollection) ? $"{prop.Type}Collection" : prop.Type;
                    var type = this.Dependencies.FirstOrDefault(dep => dep.Type == propType);
                    return new SchemaField(prop, this.EdmStructuredType.Keys, type as AngularRenderable); 
                    });
        public IEnumerable<Angular.ModelProperty> Properties => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => new Angular.ModelProperty(prop));
        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                EntityType = this.EntityType,
                SchemaName = this.SchemaName
            };
        }
    }
}