using System;
using System.Linq;

namespace Od2Ts.Abstracts
{
    public class Import
    {
        public Uri Uri {get; private set;}
        public Import(Uri uri) {
            this.Uri = uri;
        }
    }
}
