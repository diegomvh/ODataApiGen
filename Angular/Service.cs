using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public abstract class Service : AngularRenderable, ILiquidizable
    {
        public Service() { }

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
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public override bool Overwrite => true;
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

        protected IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables)
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

                var returnType = AngularRenderable.GetType(callable.ReturnType);

                var typescriptType = AngularRenderable.GetTypescriptType(callable.ReturnType);
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
                    $"{p.Name}: {AngularRenderable.GetTypescriptType(p.Type)}" +
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
                    $"'{callableFullName}', '{returnType}');" +
                    $"\n    return res.call(args, '{responseType}', options);\n  }}";
            }
        }

        protected IEnumerable<string> RenderReferences(IEnumerable<Models.NavigationPropertyBinding> bindings)
        {
            foreach (var binding in bindings)
            {
                var nav = binding.NavigationProperty;
                var type = AngularRenderable.GetTypescriptType(nav.Type);

                var methodName = nav.Name.Substring(0, 1).ToLower() + nav.Name.Substring(1);

                // Navigation
                yield return $@"public {methodName}(entity: {EntityName}): ODataNavigationPropertyResource<{type}> {{
    return this.navigationProperty<{type}>(entity, '{binding.Path}');
  }}";
            }
        }
        public object ToLiquid()
        {
            return new { Name = this.Name };
        }

    }
}