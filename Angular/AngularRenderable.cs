using System;
using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public abstract class AngularRenderable : ODataApiGen.Abstracts.Renderable
    {
        public static string GetType(string type)
        {
            switch (type)
            {
                case "Edm.String":
                case "Edm.Duration":
                case "Edm.Guid":
                case "Edm.Binary":
                    return "string";
                case "Edm.Int16":
                case "Edm.Int32":
                case "Edm.Int64":
                case "Edm.Double":
                case "Edm.Decimal":
                case "Edm.Single":
                case "Edm.Byte":
                    return "number";
                case "Edm.Boolean":
                    return "boolean";
                case "Edm.DateTimeOffset":
                    return "Date";
                case "Edm.GeographyPoint":
                default:
                    {
                        return (String.IsNullOrEmpty(type) || (type.Contains(".") && !type.StartsWith("Edm"))) ? 
                            type : "Object";
                    }
            }
        }
        public static string GetTypescriptType(string type)
        {
            if (String.IsNullOrWhiteSpace(type))
                return "any";
            switch (type)
            {
                case "Edm.String":
                case "Edm.Duration":
                case "Edm.Guid":
                case "Edm.Binary":
                    return "string";
                case "Edm.Int16":
                case "Edm.Int32":
                case "Edm.Int64":
                case "Edm.Double":
                case "Edm.Decimal":
                case "Edm.Single":
                case "Edm.Byte":
                    return "number";
                case "Edm.Boolean":
                    return "boolean";
                case "Edm.DateTimeOffset":
                    return "Date";
                default:
                    {
                        return type.Contains(".") && !type.StartsWith("Edm") ?
                            type.Split('.').Last(a => !String.IsNullOrWhiteSpace(a)) : "any";
                    }
            }
        }
        public IEnumerable<string> CallableNamespaces(Callable callable)
        {
            var uriList = new List<string>();
            if (!string.IsNullOrWhiteSpace(callable.ReturnType) && !callable.IsEdmReturnType)
            {
                uriList.Add(callable.ReturnType);
            }
            if (!string.IsNullOrWhiteSpace(callable.BindingParameter))
            {
                uriList.Add(callable.BindingParameter);
            }
            foreach (var param in callable.Parameters)
            {
                uriList.Add(param.Type);
            }
            return uriList;
        }
        public IEnumerable<string> RenderImports()
        {
            return this.GetImportRecords().Select(r =>
            {
                var path = r.From.ToString();
                if (!path.StartsWith("../"))
                    path = $"./{path}";
                return $"import {{ {String.Join(", ", r.Names)} }} from '{path}';";
            });
        }
        protected virtual IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables)
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
        public abstract IEnumerable<Import> Imports { get; }
        protected IEnumerable<Import> GetImportRecords()
        {
            var records = this.Dependencies.Where(a => a.Uri != this.Uri).GroupBy(i => i.Uri).Select(group =>
            {
                var uri = this.Uri.MakeRelativeUri(group.First().Uri);
                var names = group.SelectMany(d => d.ExportTypes).Distinct();
                return new Import(names, uri);
            });
            return records;
        }
    }
}