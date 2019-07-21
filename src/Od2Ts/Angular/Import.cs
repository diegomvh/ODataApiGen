using System;
using System.Collections.Generic;

namespace Od2Ts.Angular
{
    public class Import
    {
        public IEnumerable<string> Names { get; set; }
        public Uri From { get; set; }
        public Import(IEnumerable<string> names, Uri from)
        {
            this.Names = names;
            this.From = from;
        }
    }
}