using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class Collection : AngularRenderable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Model Model { get; private set; }
        public Angular.Service Service {get; private set;}

        public Collection(StructuredType type)
        {
            EdmStructuredType = type;
        }
        public void SetModel(Model model)
        {
            this.Model = model;
        }
        
        public void SetService(Service service)
        {
            this.Service = service;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => this.Model.ExportTypes.Distinct();
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.EdmStructuredType.Name + "Collection";
        public override string NameSpace => this.EdmStructuredType.NameSpace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public string GetSignature()
        {
            var signature = $"class {this.Name}";
            if (this.EdmStructuredType is ComplexType)
                signature = $"{signature} extends Collection";
                //signature = $"{signature} extends Collection<{this.GetTypescriptType(this.EdmStructuredType.Type)}>";
            else
                signature = $"{signature} extends ODataCollection";
                //signature = $"{signature} extends ODataCollection<{this.GetTypescriptType(this.EdmStructuredType.Type)}>";
            return signature;
        }
        public override string Render()
        {
            var parts = new List<string>();
            var imports = String.Join("\n", this.RenderImports());
            return $@"{String.Join("\n", imports)}
import {{ Collection, ODataCollection }} from 'angular-odata';

export {this.GetSignature()} {{
  static set = '{(this.Service != null ? this.Service.EdmEntitySet.EntitySetName : "")}';
  static type = '{this.Type}';
  static modelType = '{this.Model.Type}';
}}";
        }

        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".collection";
    }
}