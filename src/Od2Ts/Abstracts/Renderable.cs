using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Od2Ts.Abstracts
{
    public class ImportRecord
    {
        public IEnumerable<string> Names { get; set; }
        public Uri From { get; set; }
        public ImportRecord(IEnumerable<string> names, Uri from) {
            this.Names = names;
            this.From = from;
        }
    }

    public abstract class Renderable {
        public abstract string Name { get; }
        public abstract string FileName { get; }
        public abstract string Directory { get; }
        public abstract IEnumerable<string> ImportTypes {get; }
        public abstract IEnumerable<string> ExportTypes { get; }
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
                    return "String";
                case "Edm.Int16":
                case "Edm.Int32":
                case "Edm.Int64":
                case "Edm.Double":
                case "Edm.Decimal":
                case "Edm.Single":
                case "Edm.Byte":
                    return "Number";
                case "Edm.Boolean":
                    return "Boolean";
                case "Edm.DateTimeOffset":
                    return "Date";
                default:
                    {
                        return type.Contains(".") && !type.StartsWith("Edm") ? 
                            type.Split('.').Last(a => !String.IsNullOrWhiteSpace(a)) : "any";
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
                var path = r.From.ToString();
                if (!path.StartsWith("../"))
                    path = $"./{path}";
                return $"import {{ {String.Join(", ", r.Names)} }} from '{path}';";
            });
        }

        protected IEnumerable<ImportRecord> GetImportRecords()
        {
            var records = this.Dependencies.Where(a => a.Uri != this.Uri).GroupBy(i => i.Uri).Select(group =>
            {
                var uri = this.Uri.MakeRelativeUri(group.First().Uri);
                var names = group.SelectMany(d => d.ExportTypes);
                return new ImportRecord(names, uri);
            });
            return records;
        }
    }
}