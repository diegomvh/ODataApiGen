using System;
using System.Collections.Generic;
using System.Linq;

namespace ODataApiGen.Angular
{
    public class Index : AngularRenderable
    {
        public Angular.Package Package {get; private set;}
        public Index(Angular.Package package)
        {
            this.Package = package;
        }
        // Imports
        public override IEnumerable<string> ImportTypes 
        {
            get { 
                var ns = new List<String>();
                ns.AddRange(Package.Enums.SelectMany(e => e.ImportTypes));
                ns.AddRange(Package.Entities.SelectMany(m => m.ImportTypes));
                ns.AddRange(Package.Models.SelectMany(m => m.ImportTypes));
                ns.AddRange(Package.Schemas.SelectMany(m => m.ImportTypes));
                ns.AddRange(Package.Services.Select(s => s.EntityType ));
                ns.AddRange(Package.Module.ImportTypes);
                ns.AddRange(Package.Config.ImportTypes);
                return ns;
            }
        }
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] {};
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.EndpointName;
        public override string NameSpace => "";
        public override string FileName => "index";
        public override string Directory => this.NameSpace;
        public IEnumerable<string> Exports =>this.GetImportRecords().Select(import => $"export * from './{import.From}'");
    }
}
