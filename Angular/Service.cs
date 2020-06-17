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
        public Service(ApiOptions options) : base(options) { }

        public Angular.Entity Entity { get; private set; }
        public void SetEntity(Angular.Entity entity)
        {
            this.Entity = entity;
        }
        public Angular.Model Model { get; private set; }
        public void SetModel(Angular.Model model)
        {
            this.Model = model;
        }
        public Angular.Collection Collection { get; private set; }
        public void SetCollection(Angular.Collection collection)
        {
            this.Collection = collection;
        }
        public abstract string EntitySetName {get;}
        public abstract string EntityType {get;}
        public abstract string EntityName {get;}
        public abstract IEnumerable<Models.Annotation> Annotations {get;}
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

        protected IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables, bool useset = false, bool usename = false)
        {
            var names = allCallables.GroupBy(c => c.Name).Select(c => c.Key);
            foreach (var name in names)
            {
                var callables = allCallables.Where(c => c.Name == name);
                var overload = callables.Count() > 1;
                var callable = callables.FirstOrDefault();
                var methodName = name[0].ToString().ToLower() + name.Substring(1);

                var callableFullName = callable.IsBound ? $"{callable.Namespace}.{callable.Name}" : callable.Name;

                var baseMethodName = callable.IsCollection
                    ? $"collection{callable.Type}"
                    : $"{callable.Type.ToLower()}";

                if (!callable.IsBound) {
                    // Create function from odata client
                    baseMethodName = $"client.{baseMethodName}";
                }

                var returnType = this.ResolveType(callable.ReturnType);

                var typescriptType = this.ResolveTypescriptType(callable.ReturnType);
                var callableReturnType = callable.IsEdmReturnType ?
                        $"[{typescriptType}, ODataValueAnnotations]" :
                    callable.ReturnsCollection ?
                        $"[{typescriptType}[], ODataEntitiesAnnotations]" :
                        $"[{typescriptType}, ODataEntityAnnotations]";

                var responseType = callable.IsEdmReturnType ?
                        $"value" :
                    callable.ReturnsCollection ?
                        $"entities" :
                        $"entity";

                var parameters = new List<Models.Parameter>();
                foreach (var cal in callables)
                    parameters.AddRange(cal.Parameters);
                var optionals = parameters.Where(p =>
                    !callables.All(c => c.Parameters.Contains(p))).ToList();
                parameters = parameters.GroupBy(p => p.Name).Select(g => g.First()).ToList();

                var argumentWithType = new List<string>();
                var boundArgument = callable.IsBound && !callable.IsCollection?
                    callable.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)).ToLower() + "Id" :
                    "";

                if (callable.IsBound && !callable.IsCollection)
                    argumentWithType.Add($"{boundArgument}: any");

                argumentWithType.AddRange(parameters.Select(p =>
                    $"{p.Name}: {this.ResolveTypescriptType(p.Type)}" +
                    (p.IsCollection ? "[]" : "") +
                    (optionals.Contains(p) ? " = null" : "")
                ));
                argumentWithType.Add(@"options?: HttpOptions");

                var args = "let args = null;";
                if (parameters.Count() > 0) {
                    args = "let args = Object.entries({" +
                        String.Join(", ", parameters.Select(p => p.IsEdmType ? 
                            $"\n        {p.Name}: {p.Name}":
                            $"\n        {p.Name}: this.client.parserForType('{p.Type}').toJSON({p.Name})")) +
                    "\n      })" +
                    "\n      .filter(pair => pair[1] !== null)" +
                    "\n      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});";
                }
                yield return $"public {methodName}({String.Join(", ", argumentWithType)}): Observable<{callableReturnType}> {{" +
                    $"\n    {args}" +
                    $"\n    var res = this.{baseMethodName}<{typescriptType}>(" + 
                    (String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $"{boundArgument}, ") +
                    $"'{callableFullName}'" +
                    (String.IsNullOrWhiteSpace(returnType) ? ");" : $", '{returnType}');") +
                    (useset ? $"\n    res.entitySet('{this.EntitySetName}');" : "") +
                    (usename ? $"\n    options = Object.assign({{config: '{this.Options.Name}'}}, options || {{}});" : "") +
                    $"\n    return res.call(args, '{responseType}', options);\n  }}";
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

                var type = navEntity.Name;
                if (propertyEntity != null && bindingEntity.IsBaseOf(propertyEntity)) {
                    var castName = $"as{propertyEntity.Name}";
                    if (!casts.Contains(propertyEntity.FullName)) {
                        // Cast
                        type = propertyEntity.Name;
                        yield return $@"public {castName}(): ODataEntitySetResource<{type}> {{
    return this.entities().cast<{type}>('{propertyEntity.FullName}');
  }}";
                        casts.Add(propertyEntity.FullName);
                    }
                    var methodName = castName + nav.Name.Substring(0, 1).ToUpper() + nav.Name.Substring(1);

                    // Navigation
                    yield return $@"public {methodName}(entity: EntityKey<{EntityName}>): ODataNavigationPropertyResource<{type}> {{
    return this.{castName}().entity(entity).navigationProperty<{type}>('{binding.PropertyName}');
  }}";

                } else {
                    var methodName = nav.Name.Substring(0, 1).ToLower() + nav.Name.Substring(1);

                    // Navigation
                    yield return $@"public {methodName}(entity: EntityKey<{EntityName}>): ODataNavigationPropertyResource<{type}> {{
    return this.entity(entity).navigationProperty<{type}>('{binding.Path}');
  }}";
                }
            }
        }
        public object ToLiquid()
        {
            return new { Name = this.Name };
        }

    }
}