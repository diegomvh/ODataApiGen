using System;
using System.Collections.Generic;
using System.IO;

namespace Od2Ts.Abstracts
{
    public abstract class Renderable {
        public abstract string Name { get; }
        public abstract string FileName { get; }
        public abstract string Directory { get; }
        public abstract IEnumerable<string> ImportTypes {get; }
        public abstract IEnumerable<string> ExportTypes { get; }
        public abstract string Render();
        public Uri Uri => !String.IsNullOrEmpty(Directory) ? new Uri($"r://{Directory}{Path.DirectorySeparatorChar}{FileName}", UriKind.Absolute) : new Uri($"r://{FileName}");
        public List<Renderable> Dependencies {get; set;} = new List<Renderable>();
    }
}