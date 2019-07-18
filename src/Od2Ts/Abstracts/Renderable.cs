using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Od2Ts.Abstracts
{
    public class ImportRecord
    {
        public string Name { get; set; }
        public Uri RelativeNamespace { get; set; }
    }

    public abstract class Renderable {
        public abstract string Name { get; }
        public abstract string FileName { get; }
        public abstract string Directory { get; }
        public abstract IEnumerable<string> Types {get; }
        public abstract string Render();
        public string GetTypescriptType(string type)
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
                        return type.Contains(".") ? type.Split('.').Last(a => !String.IsNullOrWhiteSpace(a)) : "any";
                    }
            }
        }
        public Uri Uri => !String.IsNullOrEmpty(Directory) ? new Uri($"r://{Directory}{Path.DirectorySeparatorChar}{FileName}", UriKind.Absolute) : new Uri($"r://{FileName}");
        public List<Renderable> Dependencies {get; set;} = new List<Renderable>();
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
            return uriList;
        }
        public IEnumerable<string> RenderImports()
        {
            return this.GetImportRecords().Select(r => {
                var path = r.RelativeNamespace.ToString();
                if (!path.StartsWith("../"))
                    path = $"./{path}";
                return $"import {{ {r.Name} }} from '{path}';";
            });
        }

        public IEnumerable<ImportRecord> GetImportRecords()
        {
            var records = this.Dependencies.Where(a => a.Uri != this.Uri).GroupBy(i=> i.Uri).Select(group =>
            {
                var a = group.First();
                var record = new ImportRecord()
                {
                    RelativeNamespace = this.Uri.MakeRelativeUri(a.Uri),
                    Name = a.Name
                };
                return record;
            });
            return records;
        }
    }
}