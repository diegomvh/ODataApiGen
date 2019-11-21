using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ODataApiGen.Angular
{
    public class Module : AngularRenderable
    {
        public static ILogger Logger { get; } = Program.CreateLogger<Module>();
        public Angular.Package Package {get; private set;}
        public Module(Package package)
        {
            Package = package;
        }
        public override string Name => this.Package.EndpointName + "Module";
        public override string NameSpace => "";
        public override string FileName => this.Package.EndpointName.ToLower() + ".module";
        public override string Directory => this.NameSpace;
        public IEnumerable<Service> Services => this.Package.Services;
        // Imports and Exports
        public override IEnumerable<string> ImportTypes => this.Package.Services.Select(a => a.EntityType);
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
    }
}
