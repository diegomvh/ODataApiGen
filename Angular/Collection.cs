using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class Collection : Structured
    {
        public Angular.Model Model { get; private set; }
        public Collection(StructuredType type, Angular.Model model, ApiOptions options) : base(type, options)
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
                    this.Model.Entity.EdmStructuredType.FullName
                };
                list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
                if (this.EdmEntityType != null) {
                    list.AddRange(this.EdmEntityType.NavigationProperties.Select(a => a.Type));
                    list.AddRange(this.EdmEntityType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                    list.AddRange(this.EdmEntityType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                    foreach (var cal in this.EdmEntityType.Actions)
                        parameters.AddRange(cal.Parameters);
                    foreach (var cal in this.EdmEntityType.Functions)
                        parameters.AddRange(cal.Parameters);
                    list.AddRange(parameters.Select(p => p.Type));
                }
                return list;
            }
        }
        // Exports
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".collection";
        public override string Name => Utils.ToTypescriptName(this.EdmStructuredType.Name, TypeScriptElement.Class) + "Collection";
        public string ModelName => this.Model.ImportedName;
        public override IEnumerable<Import> Imports => GetImportRecords();

        public override object ToLiquid()
        {
            return new {
                Name = this.ImportedName,
                Type = this.Type
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