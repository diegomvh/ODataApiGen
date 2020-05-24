using System;
using System.Collections.Generic;
using System.IO;
using ODataApiGen.Models;

namespace ODataApiGen.Abstracts
{
    public abstract class Package {
        public string EndpointName {get; private set;}
        public string MetadataPath {get; private set;}
        public bool CreateModels {get; private set;}
        public Package(string endpointName, string metadataPath, bool models)
        {
            this.EndpointName = endpointName;
            this.MetadataPath = metadataPath;
            this.CreateModels = models;
        }
        public abstract IEnumerable<Renderable> Renderables { get; }
        public abstract void LoadMetadata(Metadata metadata);

    }
}