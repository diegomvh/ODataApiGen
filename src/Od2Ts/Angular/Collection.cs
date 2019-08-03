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

        public Collection(StructuredType type)
        {
            EdmStructuredType = type;
        }

        public void SetModel(Model model)
        {
            this.Model = model;
        }

        public override string Name => this.EdmStructuredType.Name + "Collection";
        public override string NameSpace => this.EdmStructuredType.NameSpace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var types = this.Model.ExportTypes
                    .ToList();
                return types.Distinct();
            }
        }
        public string GetSignature()
        {
            var signature = $"class {this.Name}";
            if (this.EdmStructuredType is ComplexType)
                signature = $"{signature} extends Collection<{this.GetTypescriptType(this.EdmStructuredType.Type)}>";
            else
                signature = $"{signature} extends ODataCollection<{this.GetTypescriptType(this.EdmStructuredType.Type)}>";
            return signature;
        }
        public override string Render()
        {
            var parts = new List<string>();
            var imports = String.Join("\n", this.RenderImports());
            return $@"{String.Join("\n", imports)}
import {{ Collection, ODataCollection }} from 'angular-odata';

export {this.GetSignature()} {{
  static type = '{this.Type}';
  static Model = {this.GetTypescriptType(this.EdmStructuredType.Type)};
}}";
        }

        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".collection";
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
    }
}