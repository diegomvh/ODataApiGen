using ODataApiGen.Abstracts;

namespace ODataApiGen.Flutter
{
    public class Collection : StructuredType
    {
        public Flutter.Model Model { get; private set; }
        public Collection(Models.StructuredType type, Flutter.Model model, ApiOptions options) : base(type, options)
        {
            this.Model = model;
        }

        // Imports
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                var list = new List<string> {
                    this.Model.Entity.EdmStructuredType.NamespaceQualifiedName
                };
                list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
                if (this.EdmEntityType != null) {
                    list.AddRange(this.EdmEntityType.Properties.Select(a => a.Type));
                    list.AddRange(this.EdmEntityType.NavigationProperties.Select(a => a.Type));
                    list.AddRange(this.EdmEntityType.NavigationProperties.Select(a => a.ToEntityType));
                    list.AddRange(this.EdmEntityType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                    list.AddRange(this.EdmEntityType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                    foreach (var cal in this.EdmEntityType.Actions)
                        parameters.AddRange(cal.Parameters);
                    foreach (var cal in this.EdmEntityType.Functions)
                        parameters.AddRange(cal.Parameters);
                    list.AddRange(parameters.Select(p => p.Type));
                }
                return list.Where(t => !String.IsNullOrWhiteSpace(t) && !t.StartsWith("Edm.")).Distinct();
            }
        }
        // Exports
        public override string FileName => this.EdmStructuredType.Name.Dasherize() + ".collection";
        public override string Name => Utils.ToDartName(this.EdmStructuredType.Name, DartElement.Class) + "Collection";
        public string ModelName => this.Model.ImportedName;
        public override IEnumerable<Import> Imports => GetImportRecords();

        public override object ToLiquid()
        {
            return new {
                Name = this.ImportedName,
            };
        }

        public IEnumerable<string> Actions {
            get {
                if (this.EdmEntityType != null) {
                    var collectionActions = this.EdmEntityType.Actions.Where(a => a.IsCollection);
                    return collectionActions.Count() > 0 ? this.RenderCallables(collectionActions) : Enumerable.Empty<string>();
                }
                return Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Functions {
            get {
                if (this.EdmEntityType != null) {
                    var collectionFunctions = this.EdmEntityType.Functions.Where(a => a.IsCollection);
                    return collectionFunctions.Count() > 0 ? this.RenderCallables(collectionFunctions) : Enumerable.Empty<string>();
                }
                return Enumerable.Empty<string>();
            }
        }
    }
}