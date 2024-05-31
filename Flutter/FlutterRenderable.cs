using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Flutter
{
    public abstract class FlutterRenderable : ODataApiGen.Abstracts.Renderable
    {
        public FlutterRenderable(ApiOptions options) : base(options) {}
        public override string FileExtension => ".dart";
        public string _ToTypescriptName(string name, DartElement e) {
            return Utils.ToDartName(name, e);
        }
        public string ToTypescriptType(string type)
        {

            return Utils.ToDartType(type, Options.GeoJson);
        }
        public IEnumerable<string> CallableNamespaces(Callable callable)
        {
            var uriList = new List<string>();
            if (!string.IsNullOrWhiteSpace(callable.ReturnType) && !callable.IsEdmReturnType)
            {
                uriList.Add(callable.ReturnType);
            }
            if (!string.IsNullOrWhiteSpace(callable.BindingParameter?.Type))
            {
                uriList.Add(callable.BindingParameter.Type);
            }
            foreach (var param in callable.Parameters)
            {
                uriList.Add(param.Type);
            }
            return uriList;
        }
        public IEnumerable<string> RenderImports()
        {
            return this.GetImportRecords().Select(import =>
            {
                var path = import.From.ToString();
                if (!path.StartsWith("../"))
                    path = $"./{path}";
                return $"import {{ {String.Join(", ", import.Names)} }} from '{path}';";
            });
        }
        public abstract IEnumerable<Import> Imports { get; }
        protected IEnumerable<Import> GetImportRecords()
        {
            var records = this.Dependencies
                .Where(a => a.Item2.Uri != this.Uri)
                .GroupBy(i => i.Item2.Uri).Select(group =>
            {
                var uri = this.Uri.MakeRelativeUri(group.First().Item2.Uri);
                var names = group.Select(d => {
                    if (d.Item1 != d.Item2.Name) {
                        d.Item2.ImportedName = d.Item1;
                        return $"{d.Item2.Name} as {d.Item1}";
                    } else {
                        d.Item2.ImportedName = d.Item2.Name;
                        return d.Item1;
                    }
                    }).Distinct();
                return new Import(names, uri);
            });
            return records;
        }
    }
}