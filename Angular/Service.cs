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

        public Angular.Entity Interface { get; private set; }
        public void SetInterface(Angular.Entity inter)
        {
            this.Interface = inter;
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
                var entity = binding.EntityType;
                var nav = binding.NavigationProperty;
                Console.WriteLine(nav.Name);
                var type = entity.Name;
                var name = nav.Name[0].ToString().ToUpper() + nav.Name.Substring(1);
                var methodRelationName = nav.Name;

                var methodCreateName = nav.IsCollection ? $"add{type}To{name}" : $"set{type}As{name}";
                var methodDeleteName = nav.IsCollection ? $"remove{type}From{name}" : $"unset{type}As{name}";

                var returnType = nav.IsCollection ? 
                    $"[{type}[], ODataEntitiesAnnotations]" : 
                    $"[{type}, ODataEntityAnnotations]";

                // Navigation
                yield return $@"public {methodRelationName}(entity: {EntityName}, options?: HttpOptions): Observable<{returnType}> {{
    return this.navigationProperty<{type}>(entity, '{binding.Path}')
      .{(nav.IsCollection ? "collection" : "single")}(options);
  }}";
                // Link
                yield return $@"public {methodCreateName}<{type}>(entity: {EntityName}, target: ODataEntityResource<{type}>, etag?: string): Observable<any> {{
    return this.navigationProperty<{type}>(entity, '{binding.Path}').reference()
      .{(nav.IsCollection ? "add" : "set")}(target{(nav.IsCollection ? "" : ", {etag}")});
  }}";
                // Unlink
                yield return $@"public {methodDeleteName}<{type}>(entity: {EntityName}, target?: ODataEntityResource<{type}>, etag?: string): Observable<any> {{
    return this.navigationProperty<{type}>(entity, '{binding.Path}').reference()
      .remove({{etag, target}});
  }}";
            }
        }
        public object ToLiquid()
        {
            return new { Name = this.Name };
        }

    }
}