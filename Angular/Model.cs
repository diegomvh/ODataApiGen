using System.Collections.Generic;
using System.Linq;
using System.IO;
using ODataApiGen.Models;
using System;

namespace ODataApiGen.Angular
{
    public class ModelProperty : EntityProperty 
    {
        public ModelProperty(ODataApiGen.Models.Property prop) : base(prop)
        {
            Navigation = prop is NavigationProperty;
        }
        public bool Navigation {get;private set;}
        public override string Name => Value.Name + ((Navigation || Value.Nullable) ? "?" : "");
        public override string Type => AngularRenderable.GetTypescriptType(Value.Type) + 
            (Value.Collection ? Value.IsEdmType ? "[]" : "Collection" : "");
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
            var baseMethodRelationName = nav.Collection ? $"relatedCollection" : $"relatedModel";
            var returnType = (nav.Collection) ?
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
            var methodCreateName = nav.Collection ? $"add{type}To{name}" : $"set{type}As{name}";
            var methodDeleteName = nav.Collection ? $"remove{type}From{name}" : $"unset{type}As{name}";
            var baseMethodRelationName = nav.Collection ? $"relatedODataCollection" : $"relatedODataModel";
            var baseMethodCreateName = nav.Collection ? $"createODataCollectionRef" : $"createODataModelRef";
            var baseMethodDeleteName = nav.Collection ? $"deleteODataCollectionRef" : $"deleteODataModelRef";
            var returnType = (nav.Collection) ?
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