using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Interfaces;

namespace Od2Ts.Models
{
    public class AngularModule : IHasImports
    {
        public AngularModule(string endpointName, IEnumerable<EntitySet> entitySets)
        {
            EntitySets = entitySets;
            Name = endpointName;
            NameSpace = string.Empty;
        }

        public string Name { get; }
        public string NameSpace { get; }

        private Uri _uri;
        public readonly IEnumerable<EntitySet> EntitySets;

        public Uri Uri => _uri ?? (_uri = new Uri("r://"  + Name, UriKind.Absolute));

        public IEnumerable<Uri> Imports(bool useInterface)
        {
            return EntitySets.Select(a => a.Uri);
        }
    }
}
