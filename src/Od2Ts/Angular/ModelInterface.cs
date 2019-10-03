using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ModelInterface : Model
    {
        public ModelInterface(StructuredType type) : base(type)
        {
        }
        public string GetSignature()
        {
            var signature = $"interface {this.Name}";
            if (this.Base != null)
                signature = $"{signature} extends {this.Base.Name}";
            return signature;
        }
        protected string RenderProperty(Property prop)
        {
            return $"{prop.Name}" +
                (prop.IsNullable ? "?:" : ":") +
                $" {this.GetTypescriptType(prop.Type)}" +
                (prop.IsCollection ? "[];" : ";");
        }
        public override string Render()
        {
            var properties = this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop =>
                    this.RenderProperty(prop)
                );

            var imports = this.RenderImports();
            return $@"{String.Join("\n", imports)}

export {this.GetSignature()} {{
  {String.Join("\n  ", properties)}
}}";
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".interface";
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
    }
}