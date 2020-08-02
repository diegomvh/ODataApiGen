using System.Collections.Generic;

namespace ODataApiGen.Abstracts
{
    public abstract class Package {
        public ApiOptions Options  {get; set;} 
        public string Name => this.Options.Name;
        public string ServiceRootUrl => this.Options.ServiceRootUrl;
        public string Version => this.Options.Version;
        public Package(ApiOptions options)
        {
            this.Options = options;
        }
        public abstract IEnumerable<Renderable> Renderables { get; }
        public abstract void Build();
        public abstract void ResolveDependencies();

        public abstract IEnumerable<string> GetAllDirectories();

    }
}