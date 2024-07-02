namespace ODataApiGen.Abstracts
{
    public class ApiOptions {
        public string Name {get; set;}
        public string Version {get; set;}
        public string ServiceRootUrl {get; set;}
        public bool Models {get; set;}
        public bool GeoJson {get; set;}
    }
    public abstract class Renderable {
        public ApiOptions Options  {get; set;} 
        public Renderable(ApiOptions options) {
            this.Options = options;
        }
        // About Identity
        public abstract string Name { get; }
        public abstract string Namespace { get; }
        public string FullName => $"{this.Namespace}.{this.Name}";

        // About File
        public abstract string FileName { get; }
        public abstract string FileExtension { get; }
        public abstract string Directory { get; }
        public Uri Uri => !String.IsNullOrEmpty(Directory) ? new Uri($"r://{Directory}{Path.DirectorySeparatorChar}{FileName}", UriKind.Absolute) : new Uri($"r://{FileName}");

        // About Template
        public string TemplateFile => this.GetType().Name + this.FileExtension;
        // About References
        public string ImportedName {get;set;} = String.Empty;
        public void CleanImportedNames() {
            foreach (var dependency in this.Dependencies) {
               dependency.Item2.ImportedName = dependency.Item2.Name; 
            }
        }
        public abstract IEnumerable<string> ImportTypes {get; }
        protected List<Tuple<string, Renderable>> Dependencies {get; set;} = new List<Tuple<string, Renderable>>();
        public void AddDependency(Renderable renderable) {
            if (this.Dependencies.All(d => d.Item2 != renderable)) {
                var alias = renderable.Name;
                while (this.Dependencies.Any(d => d.Item1 == alias)) {
                    alias = NameGenerator.GetRandomName();
                }
                this.Dependencies.Add(Tuple.Create<string, Renderable>(alias, renderable));
            }
        }

        public void AddDependencies(IEnumerable<Renderable> renderables) {
            foreach (var renderable in renderables)
                this.AddDependency(renderable);
        }
    }
}