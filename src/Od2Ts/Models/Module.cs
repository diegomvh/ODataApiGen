using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Interfaces;

namespace Od2Ts.Models
{
    public class Module : IHasImports
    {
        public Module(string endpointName, IEnumerable<EntityType> entityTypes, IEnumerable<EntitySet> entitySets)
        {
            EntitySets = entitySets;
            EntityTypes = entityTypes;
            Name = endpointName;
            NameSpace = string.Empty;
        }

        public string Name { get; }
        public string NameSpace { get; }

        private Uri _uri;
        public readonly IEnumerable<EntitySet> EntitySets;
        public readonly IEnumerable<EntityType> EntityTypes;

        public Uri Uri => _uri ?? (_uri = new Uri("r://" + Name, UriKind.Absolute));

        public IEnumerable<Import> Imports
        {
            get
            {
                var list = new List<Import>
                {
                    new Import(
                        new Uri("r://ODataContext", UriKind.Absolute)
                    )
                };
                list.AddRange(EntitySets.Select(a => new Import(a.Uri)));
                return list;
            }
        }
    }
}
