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
        public override IEnumerable<string> ImportTypes => Enumerable.Empty<string>();
        // Exports
        public override IEnumerable<string> ExportTypes => Enumerable.Empty<string>();
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.Name;
        public override string NameSpace => "";
        public override string FileName => "index";
        public override string Directory => this.NameSpace;
        public IEnumerable<string> Exports =>this.GetImportRecords().Select(import => $"export * from './{import.From}'");
    }
}
