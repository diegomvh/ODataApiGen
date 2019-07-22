using System;
using System.Collections.Generic;
using System.IO;

namespace Od2Ts.Abstracts
{
    public abstract class Package {
        public string EndpointName {get; private set;}
        public string MetadataPath {get; private set;}
        public bool Secure {get; private set;}
        public string Version {get; private set;}
        public Package(string endpointName, string metadataPath, bool secure, string version)
        {
            this.EndpointName = endpointName;
            this.MetadataPath = metadataPath;
            this.Secure = secure;
            this.Version = version;
        }
        public abstract IEnumerable<Renderable> Renderables { get; }
        public abstract void LoadMetadata(MetadataReader reader);

    }
}