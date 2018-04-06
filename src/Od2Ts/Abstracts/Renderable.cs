using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Extensions;
using Od2Ts.Interfaces;

namespace Od2Ts.Abstracts
{
    public abstract class Renderable {
        public abstract string Name { get; }
        public abstract string NameSpace { get; }
        public abstract string Render();
        public string GetTypescriptType(string type)
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
        public Uri BuildUri(params string[] names) {
            var parts = names.SelectMany(part => part.Split("."));
            return new Uri("r://" + String.Join(Path.DirectorySeparatorChar.ToString(), parts), UriKind.Absolute);
        }
        public IEnumerable<Import> BuildCallableImports(Callable callable)
        {
            var uriList = new List<Import>();
            if (!string.IsNullOrWhiteSpace(callable.ReturnType) && !callable.IsEdmReturnType)
            {
                uriList.Add(new Import(this.BuildUri(callable.ReturnType)));
            }
            if (!string.IsNullOrWhiteSpace(callable.BindingParameter))
            {
                uriList.Add(new Import(this.BuildUri(callable.BindingParameter)));
            }
            return uriList;
        }
        public IEnumerable<string> RenderImports(IHasImports renderable)
        {
            return renderable.GetImportRecords().Select(a =>
                $"import {{ {a.ElementTypeName} }} from './{a.RelativeNamespace}';");
        }
    }
}