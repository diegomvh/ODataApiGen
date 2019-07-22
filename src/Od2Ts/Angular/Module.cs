using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Od2Ts.Angular
{
    public class Module : AngularRenderable
    {
        public static ILogger Logger { get; } = Program.CreateLogger<Module>();
        public override string Name => this.Package.EndpointName + "Module";
        public override string FileName => this.Package.EndpointName.ToLower() + ".module";
        public override string Directory => "";
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                return this.Package.Services.Select(a => a.EdmEntitySet.EntityType);
            }
        }

        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

        public Angular.AngularPackage Package {get; private set;}
        public Module(AngularPackage package)
        {
            Package = package;
        }

        public override string Render()
        {
            var imports = this.RenderImports();

            return $@"import {{ NgModule }} from '@angular/core';

{String.Join("\n", imports)}

@NgModule({{
  providers: [
    {String.Join(",\n    ", this.Package.Services.Select(set => set.Name))}
  ]
}})
export class {this.Name} {{ }}";
        }
    }
}
