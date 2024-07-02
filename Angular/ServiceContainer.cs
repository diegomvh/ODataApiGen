using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class ServiceContainer : Service 
    {
        public Angular.EntityContainerConfig Container {get; private set;}
        public ServiceContainer(Angular.EntityContainerConfig container, ApiOptions options) : base(options)
        {
            Container = container;
        }
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.Container.EdmEntityContainer.UnboundActions)
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.Container.EdmEntityContainer.UnboundFunctions)
                    parameters.AddRange(cal.Parameters);

                var list = new List<string>();
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(this.Container.EdmEntityContainer.UnboundActions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.Container.EdmEntityContainer.UnboundFunctions.SelectMany(f => this.CallableNamespaces(f)));
                return list.Where(t => !String.IsNullOrWhiteSpace(t) && !t.StartsWith("Edm.")).Distinct();
            }
        }

        public override IEnumerable<Import> Imports => GetImportRecords();

        public override string Name => Utils.ToTypescriptName(this.Container.EdmEntityContainer.Name, TypeScriptElement.Class) + "Service";
        public override string Namespace => this.Container.EdmEntityContainer.Namespace;
        public override string FileName => this.Container.EdmEntityContainer.Name.ToLower() + ".service";
        public IEnumerable<string> Actions =>  this.RenderCallables(this.Container.EdmEntityContainer.UnboundActions);
        public IEnumerable<string> Functions => this.RenderCallables(this.Container.EdmEntityContainer.UnboundFunctions);
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public override IEnumerable<Models.Annotation> Annotations => Enumerable.Empty<Models.Annotation>(); 
        public override string EntityType => "";
        public override string ServiceType => this.Container.FullName;
        public string ContainerName => this.Container.Name;
        public string ApiName => this.Options.Name;
    }
}