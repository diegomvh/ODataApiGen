using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Abstracts;
using Od2Ts.Interfaces;

namespace Od2Ts.Angular {
    class Model : Renderable, IHasImports {
        public StructuredType EdmStructuredType {get; private set;}
        public bool Interface {get; set;} = false;
        public Model(StructuredType type) {
            EdmStructuredType = type;
        }
        public override string Render() {
            var properties = EdmStructuredType.Properties.Select(prop =>
                $"{prop.Name}" + (prop.IsRequired ? ":" : "?:") + $" {this.GetTypescriptType(prop.Type)};");

            var navigations = EdmStructuredType.NavigationProperties.Select(nav =>
                $"{nav.Name}" + 
                (nav.IsRequired ? ":" : "?:") + 
                $" {this.GetTypescriptType(nav.Type)}" + (nav.IsCollection ? "[];" : ";"));

            var imports = this.RenderImports(this);
            return $@"{String.Join("\n", imports)}
            export {this.GetModelType()} {this.EdmStructuredType.Name} {{
                /* Navigation properties */
                {String.Join("\n", navigations)}
                /* Properties */
                {String.Join("\n", properties)}
            }}"; 
        }

        public string GetModelType() {
            return this.Interface ? "interface" : "class";
        }
        public IEnumerable<Import> Imports
        {
            get
            {
                var namespaces = this.EdmStructuredType.NavigationProperties.Select(a => a.Type).Where(a => a != this.EdmStructuredType.NameSpace + "." + this.EdmStructuredType.Name).ToList();
                /*For Not-EDM types (e.g. enums with namespaces, complex types*/
                namespaces.AddRange(this.EdmStructuredType.Properties.Where(a => !a.Type.StartsWith("Edm.")).Select(a => a.Type));

                var uris = namespaces.Distinct().Select(a => new Import(
                    new Uri("r://" + a.Replace(".", "/"), UriKind.Absolute))
                );
                return uris;
            }
        }

        private Uri _uri;
        public Uri Uri => _uri ?? (_uri = new Uri("r://" + this.EdmStructuredType.NameSpace.Replace(".", "/") + "/" + this.EdmStructuredType.Name, UriKind.Absolute));

        public override string Name => this.EdmStructuredType.Name;

        public override string NameSpace => this.EdmStructuredType.NameSpace;
    }
}