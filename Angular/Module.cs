using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ODataApiGen.Angular
{
    public class Module : AngularRenderable
    {
        public Angular.Package Package {get; private set;}
        public Module(Package package)
        {
            Package = package;
        }
        public override string Name => this.Package.Name + "Module";
        public override string Namespace => "";
        public override string FileName => this.Package.Name.ToLower() + ".module";
        public override string Directory => this.Namespace;
        public IEnumerable<Service> Services => this.Package.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services));
        // Imports and Exports
        public override IEnumerable<string> ImportTypes => this.Package.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services)).Select(a => a.EntityType);
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
    }
}
