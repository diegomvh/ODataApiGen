using System;
using System.Collections.Generic;
using System.IO;

namespace ODataApiGen.Abstracts
{
    public abstract class Renderable {
        // About Identity
        public abstract string Name { get; }
        public abstract string NameSpace { get; }
        public string Type => $"{this.NameSpace}.{this.Name}";

        // About File
        public abstract string FileName { get; }
        public abstract string Directory { get; }
        public abstract bool Overwrite { get; }
        public Uri Uri => !String.IsNullOrEmpty(Directory) ? new Uri($"r://{Directory}{Path.DirectorySeparatorChar}{FileName}", UriKind.Absolute) : new Uri($"r://{FileName}");

        // About References
        public abstract IEnumerable<string> ImportTypes {get; }
        public abstract IEnumerable<string> ExportTypes { get; }
        public List<Renderable> Dependencies {get; set;} = new List<Renderable>();

    }
}