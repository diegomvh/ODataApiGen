using System;
using System.Collections.Generic;
using System.IO;
using ODataApiGen.Models;

namespace ODataApiGen.Abstracts
{
    public abstract class Package {
        public string Name {get; private set;}
        public Package(string name)
        {
            this.Name = name;
        }
        public abstract IEnumerable<Renderable> Renderables { get; }
        public abstract void Build(bool models);

    }
}