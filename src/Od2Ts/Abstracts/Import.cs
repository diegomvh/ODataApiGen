using System;

namespace Od2Ts.Abstracts
{
    public class Import
    {
        public string Name {get; private set;}
        public Uri Uri {get; private set;}
        public Import(string name, Uri uri) {
            this.Name = name;
            this.Uri = uri;
        }
    }
}
