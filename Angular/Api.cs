using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;

namespace ODataApiGen.Angular
{
    public class Api : Service 
    {
        public string ApiName {get; private set;}
        public Api(string name)
        {
            ApiName = name;
        }
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in Program.Metadata.UnboundActions)
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in Program.Metadata.UnboundFunctions)
                    parameters.AddRange(cal.Parameters);

                var list = new List<string>();
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(Program.Metadata.UnboundActions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(Program.Metadata.UnboundFunctions.SelectMany(f => this.CallableNamespaces(f)));
                return list;
            }
        }

        public override IEnumerable<Import> Imports => GetImportRecords();

        public override string Name => this.ApiName + "Api";
        public override string Namespace => "";
        public override string FileName => this.Name.ToLower() + ".api";
        public IEnumerable<string> Actions =>  this.RenderCallables(Program.Metadata.UnboundActions);
        public IEnumerable<string> Functions => this.RenderCallables(Program.Metadata.UnboundFunctions);
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

        public override string EntitySetName => "";

        public override string EntityType => "";

        public override string EntityName => "";
    }
}