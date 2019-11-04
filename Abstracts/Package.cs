using System;
using System.Collections.Generic;
using System.IO;

namespace ODataApiGen.Abstracts
{
    public abstract class Package {
        public string EndpointName {get; private set;}
        public string MetadataPath {get; private set;}
        public bool WithCredentials {get; private set;}
        public bool StringAsEnum {get; private set;}
        public bool CreateModels {get; private set;}
        public string Version {get; private set;}
        public Package(string endpointName, string metadataPath, bool withCredentials, bool stringAsEnum, bool models, string version)
        {
            this.EndpointName = endpointName;
            this.MetadataPath = metadataPath;
            this.WithCredentials = withCredentials;
            this.StringAsEnum = stringAsEnum;
            this.CreateModels = models;
            this.Version = version;
        }
        public abstract IEnumerable<Renderable> Renderables { get; }
        public abstract void LoadMetadata(MetadataReader reader);

    }
}