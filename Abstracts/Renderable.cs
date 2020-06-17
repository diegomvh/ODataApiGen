using System;
using System.Collections.Generic;
using System.IO;

namespace ODataApiGen.Abstracts
{
    public class ApiOptions {
        public string Name {get; set;}
        public string ServiceRootUrl {get; set;}
        public bool Models {get; set;}
        public bool GeoJson {get; set;}
        public bool Decimal {get; set;}
        public bool Guid {get; set;}
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
        public abstract IEnumerable<string> ImportTypes {get; }
        public abstract IEnumerable<string> ExportTypes { get; }
        public List<Renderable> Dependencies {get; set;} = new List<Renderable>();

    }
}