using System;
using System.Collections.Generic;
using System.Linq;

namespace Od2Ts.Angular
{
    public class Index : Renderable
    {
        public Angular.Module Module {get; private set;}
        public Index(Angular.Module module )
        {
            this.Module = module;
        }
        public override string Name => this.Module.EndpointName;
        public override string FileName => "index";
        public override string Directory => "";
        public override IEnumerable<string> ImportTypes 
        {
            get { 
                var ns = new List<String>();
                ns.AddRange(Module.Enums.SelectMany(e => e.ImportTypes));
                ns.AddRange(Module.Models.SelectMany(m => m.ImportTypes));
                ns.AddRange(Module.ImportTypes);
                return ns;
            }
        }
        public override IEnumerable<string> ExportTypes => new string[] {};
        public override string Render()
        {
            var exports = this.GetImportRecords().Select(record => $"export * from './{record.From}';");

            return $@"{String.Join("\n", exports)}
export * from './{this.Module.EndpointName.ToLower()}.config';
export * from './{this.Module.EndpointName.ToLower()}.module';";
        }
    }
}
