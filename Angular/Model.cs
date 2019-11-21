using System.Collections.Generic;
using System.Linq;
using System.IO;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ModelProperty : EntityProperty 
    {
        public ModelProperty(ODataApiGen.Models.Property prop) : base(prop)
        {
        }
        public override string Name => Value.Name + (Value.IsNullable ? "?" : "");
        public override string Type => AngularRenderable.GetTypescriptType(Value.Type) + 
            (Value.IsCollection ? Value.IsEdmType ? "[]" : "Collection" : "");
    }
    public class Model : Entity 
    {
        public Model(StructuredType type) : base(type) { }
        public Angular.Collection Collection {get; private set;}

        public void SetCollection(Collection collection)
        {
            this.Collection = collection;
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";

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
        public override IEnumerable<Angular.EntityProperty> Properties => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => new Angular.ModelProperty(prop));
    }
}