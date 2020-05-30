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