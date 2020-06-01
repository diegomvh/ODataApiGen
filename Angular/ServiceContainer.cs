using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceContainer : Service 
    {
        public Models.EntityContainer EdmEntityContainer {get; private set;}
        public ServiceContainer(EntityContainer container)
        {
            EdmEntityContainer = container;
        }
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.EdmEntityContainer.UnboundActions)
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.EdmEntityContainer.UnboundFunctions)
                    parameters.AddRange(cal.Parameters);

                var list = new List<string>();
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(this.EdmEntityContainer.UnboundActions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmEntityContainer.UnboundFunctions.SelectMany(f => this.CallableNamespaces(f)));
                return list;
            }
        }

        public override IEnumerable<Import> Imports => GetImportRecords();

        public override string Name => this.EdmEntityContainer.Name + "Service";
        public override string Namespace => this.EdmEntityContainer.Namespace;
        public override string FileName => this.EdmEntityContainer.Name.ToLower() + ".service";
        public IEnumerable<string> Actions =>  this.RenderCallables(this.EdmEntityContainer.UnboundActions);
        public IEnumerable<string> Functions => this.RenderCallables(this.EdmEntityContainer.UnboundFunctions);
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public override IEnumerable<Models.Annotation> Annotations => Enumerable.Empty<Models.Annotation>(); 
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

        public override string EntitySetName => "";

        public override string EntityType => "";

        public override string EntityName => "";
    }
}