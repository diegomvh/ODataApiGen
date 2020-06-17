using System;
using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class Index : AngularRenderable
    {
        public Angular.Package Package {get; private set;}
        public Index(Angular.Package package, ApiOptions options) : base(options)
        {
            this.Package = package;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => Enumerable.Empty<string>();
        // Exports
        public override IEnumerable<string> ExportTypes => Enumerable.Empty<string>();
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.Package.Name;
        public override string Namespace => "";
        public override string FileName => "index";
        public override string Directory => this.Namespace;
        public IEnumerable<string> Exports =>this.GetImportRecords().Select(import => $"export * from './{import.From}'");
    }
}
