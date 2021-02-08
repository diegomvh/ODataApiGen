using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public abstract class Service : AngularRenderable, ILiquidizable
    {
        public Models.EntityType EdmEntityType => this.HasModel ? this.Model.EdmEntityType : 
            this.HasEntity ? this.Entity.EdmEntityType : 
            null;
        public Service(ApiOptions options) : base(options) { }

        public Angular.Entity Entity { get; private set; }
        public void SetEntity(Angular.Entity entity)
        {
            this.Entity = entity;
        }
        public bool HasEntity => this.Entity != null;
        public string EntityName => this.HasEntity ? this.Entity.ImportedName : String.Empty;
        public Angular.Model Model { get; private set; }
        public void SetModel(Angular.Model model)
        {
            this.Model = model;
        }
        public bool HasModel => this.Model != null;
        public string ModelName => this.HasModel ? this.Model.ImportedName : String.Empty;
        public Angular.Collection Collection { get; private set; }
        public void SetCollection(Angular.Collection collection)
        {
            this.Collection = collection;
        }
        public bool HasCollection => this.Collection != null;
        public string CollectionName => this.HasCollection ? this.Collection.ImportedName : String.Empty;
        public abstract string EntitySetName {get;}
        public abstract string EntityType {get;}
        public abstract IEnumerable<Models.Annotation> Annotations {get;}
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        protected IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables)
        {
            var names = allCallables.GroupBy(c => c.Name).Select(c => c.Key);
            foreach (var name in names)
            {
                var callables = allCallables.Where(c => c.Name == name);
                var overload = callables.Count() > 1;
                var callable = callables.FirstOrDefault();
                var methodName = name[0].ToString().ToLower() + name.Substring(1);

                var callableFullName = $"{callable.Namespace}.{callable.Name}";

                var typescriptType = this.ToTypescriptType(callable.ReturnType);

                var parameters = new List<Models.Parameter>();
                var optionals = new List<string>();
                foreach (var cal in callables) {
                    foreach (var param in cal.Parameters) {
                        if (parameters.All(p => p.Name != param.Name))
                            parameters.Add(param);
                        if (optionals.All(o => o != param.Name) && !callables.All(c => c.Parameters.Any(p => p.Name == param.Name)))
                            optionals.Add(param.Name);
                    }
                }
                parameters = parameters.Where(p => !p.IsBinding).GroupBy(p => p.Name).Select(g => g.First()).ToList();

                var baseMethodName = !callable.IsBound ?
                    $"client.{callable.Type.ToLower()}" : 
                    callable.IsCollection
                    ? $"entities().{callable.Type.ToLower()}"
                    : $"entity(entity).{callable.Type.ToLower()}";

                var key = (callable.IsBound && !callable.IsCollection) ?
                    $"entity: EntityKey<{EntityName}>" :  "";

                var arguments = parameters.Select(p =>
                    $"{p.Name}" + 
                    (optionals.Any(o => o == p.Name) ? "?" : "") + 
                    $": {this.ToTypescriptType(p.Type)}" +
                    (p.IsCollection ? "[]" : ""));

                var args = "null";
                if (parameters.Count() > 0) {
                    args = $"{{{String.Join(", ", arguments)}}}";
                }
                yield return $"public {methodName}({key}): OData{callable.Type}Resource<{args}, {typescriptType}> {{" +
                    $"\n    return this.{baseMethodName}<{args}, {typescriptType}>('{callableFullName}');" +
                     "\n  }";
            }
        }

        protected IEnumerable<string> RenderReferences(IEnumerable<Models.NavigationPropertyBinding> bindings)
        {
            var casts = new List<string>();
            foreach (var binding in bindings)
            {
                var nav = binding.NavigationProperty;
                var navEntity = nav.EntityType;
                var bindingEntity = binding.EntityType;
                var propertyEntity = binding.PropertyType;

                var entity = (Program.Package as Angular.Package).FindEntity(navEntity.FullName);
                if (bindingEntity.IsBaseOf(propertyEntity)) {
                    var castName = $"as{propertyEntity.Name}";
                    if (!casts.Contains(propertyEntity.FullName)) {
                        // Cast
                        entity = (Program.Package as Angular.Package).FindEntity(propertyEntity.FullName);
                        yield return $@"public {castName}(): ODataEntitySetResource<{entity.ImportedName}> {{
    return this.entities().cast<{entity.ImportedName}>('{propertyEntity.FullName}');
  }}";
                        casts.Add(propertyEntity.FullName);
                    }
                    var methodName = castName + nav.Name.Substring(0, 1).ToUpper() + nav.Name.Substring(1);

                    // Navigation
                    yield return $@"public {methodName}(entity: EntityKey<{EntityName}>): ODataNavigationPropertyResource<{entity.ImportedName}> {{
    return this.{castName}().entity(entity).navigationProperty<{entity.ImportedName}>('{binding.PropertyName}');
  }}";

                } else if (bindingEntity != propertyEntity) {
                    var methodName = nav.Name.Substring(0, 1).ToLower() + nav.Name.Substring(1);
                    var castEntity = (Program.Package as Angular.Package).FindEntity(propertyEntity.FullName);

                    // Navigation
                    yield return $@"public {methodName}(entity: EntityKey<{EntityName}>): ODataNavigationPropertyResource<{entity.ImportedName}> {{
    return this.entity(entity).cast<{castEntity.ImportedName}>('{propertyEntity.FullName}').navigationProperty<{entity.ImportedName}>('{binding.PropertyName}');
  }}";
                } else {
                    var methodName = nav.Name.Substring(0, 1).ToLower() + nav.Name.Substring(1);

                    // Navigation
                    yield return $@"public {methodName}(entity: EntityKey<{EntityName}>): ODataNavigationPropertyResource<{entity.ImportedName}> {{
    return this.entity(entity).navigationProperty<{entity.ImportedName}>('{binding.PropertyName}');
  }}";
                }
            }
        }
        public object ToLiquid()
        {
            return new { 
                Name = this.ImportedName 
            };
        }

    }
}