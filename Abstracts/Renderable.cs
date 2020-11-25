using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        public string Type => $"{this.Namespace}.{this.Name}";

        // About File
        public abstract string FileName { get; }
        public abstract string Directory { get; }
        public Uri Uri => !String.IsNullOrEmpty(Directory) ? new Uri($"r://{Directory}{Path.DirectorySeparatorChar}{FileName}", UriKind.Absolute) : new Uri($"r://{FileName}");

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
                var other = this.Dependencies.Where(d => d.Item1 == alias).FirstOrDefault();
                var take = 1;
                while (other != null) {
                    var similar = string.Join("", renderable.Namespace.TakeWhile((ch, i) => i < other.Item2.Namespace.Length && other.Item2.Namespace[i] == ch));
                    alias = String.Join("", renderable.Namespace.Substring(similar.Length).Split('.').Take(take)) + alias;
                    other = this.Dependencies.Where(d => d.Item1 == alias).FirstOrDefault();
                    take++;
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