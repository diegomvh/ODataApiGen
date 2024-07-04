using System.Text.Json;
using System.Text.RegularExpressions;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class Api : AngularRenderable
    {
        public Angular.Package Package { get; private set; }
        public Api(Package package, ApiOptions options) : base(options)
        {
            this.Package = package;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Package.Schemas.SelectMany(m => m.ImportTypes);
        // Exports
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.Name + "Api";
        public override string Namespace => "";
        // About File
        public override string FileName => this.Package.Name.ToLower() + ".api";
        public override string Directory => this.Namespace;
        public IEnumerable<EnumTypeConfig> EnumTypeConfigs { get; set; }
        public IEnumerable<StructuredTypeConfig> StructuredTypeConfigs { get; set; }
        public IEnumerable<EntitySetConfig> EntitySetConfigs { get; set; }
        public IEnumerable<SingletonConfig> SingletonConfigs { get; set; }
        public IEnumerable<CallableConfig> CallableConfigs { get; set; }
        public IEnumerable<Models.EnumType> EnumTypes => this.EnumTypeConfigs.Select(e => e.Enum.EdmEnumType);
        public IEnumerable<Models.ComplexType> ComplexTypes => this.StructuredTypeConfigs.Select(e => e.Entity.EdmStructuredType).OfType<Models.ComplexType>();
        public IEnumerable<Models.EntityType> EntityTypes => this.StructuredTypeConfigs.Select(e => e.Entity.EdmStructuredType).OfType<Models.EntityType>();
        public IEnumerable<Models.EntitySet> EntitySets => this.EntitySetConfigs.Select(s => s.Service.EdmEntitySet);
        public IEnumerable<Models.Singleton> Singletons => this.SingletonConfigs.Select(s => s.Service.EdmSingleton);
        public IEnumerable<Models.Function> Functions => this.CallableConfigs.Select(e => e.Callable).OfType<Models.Function>();
        public IEnumerable<Models.Action> Actions => this.CallableConfigs.Select(e => e.Callable).OfType<Models.Action>();
        public string Typescript
        {
            get
            {
                var useStrings = true;
                var root = new Dictionary<string, object>();
                var elements = this.EnumTypes.Select(
                    e => new { typ = "EnumType", e.Name, e.Alias, e.Namespace, e.NamespaceQualifiedName, e.AliasQualifiedName }
                ).Union(
                    this.EntityTypes.Select(
                    e => new { typ = "EntityType", e.Name, e.Alias, e.Namespace, e.NamespaceQualifiedName, e.AliasQualifiedName })
                ).Union(
                    this.ComplexTypes.Select(
                    e => new { typ = "ComplexType", e.Name, e.Alias, e.Namespace, e.NamespaceQualifiedName, e.AliasQualifiedName })
                ).Union(
                    this.EntitySets.Select(
                    e => new { typ = "EntitySet", e.Name, e.Alias, e.Namespace, e.NamespaceQualifiedName, e.AliasQualifiedName })
                ).Union(
                    this.Functions.Select(
                    e => new { typ = "Function", e.Name, e.Alias, e.Namespace, e.NamespaceQualifiedName, e.AliasQualifiedName })
                ).Union(
                    this.Actions.Select(
                    e => new { typ = "Action", e.Name, e.Alias, e.Namespace, e.NamespaceQualifiedName, e.AliasQualifiedName })
                );
                foreach (var element in elements)
                {
                    var current = root;
                    foreach (var chunk in element.Namespace.Split("."))
                    {
                        if (!current.ContainsKey(chunk))
                        {
                            current.Add(chunk, new Dictionary<string, object>());
                        }
                        current = current[chunk] as Dictionary<string, object>;
                    }
                    if (!current.ContainsKey(element.Name))
                    {
                        if (useStrings)
                        {
                            current.Add(element.Name, element.NamespaceQualifiedName);
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(element.Alias))
                            {
                                current.Add(element.Name, new { element.typ, nqn = element.NamespaceQualifiedName, aqn = element.AliasQualifiedName });
                            }
                            else
                            {
                                current.Add(element.Name, new { element.typ, nqn = element.NamespaceQualifiedName });
                            }
                        }
                    }
                }
                var jsonText = JsonSerializer.Serialize(root, new JsonSerializerOptions() { WriteIndented = true });
                string regexPattern = "\"([^\"]+)\":"; // the "propertyName": pattern
                return Regex.Replace(jsonText, regexPattern, "$1:");
            }
        }
    }
}