using System;
using System.Linq;

namespace Od2Ts.Models
{
    public class Import
    {
        public Uri Uri {get; private set;}
        public Import(Uri uri) {
            this.Uri = uri;
        }
    }
}
