using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public abstract class Model : AngularRenderable, ILiquidizable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Model Base { get; private set; }
        public Angular.Collection Collection {get; private set;}
        public Angular.Service Service {get; private set;}
        public Model(StructuredType type)
        {
            EdmStructuredType = type;
        }

        public void SetBase(Model b)
        {
            this.Base = b;
        }
        public void SetCollection(Collection collection)
        {
            this.Collection = collection;
        }
        public void SetService(Service service)
        {
            this.Service = service;
        }

        public object ToLiquid()
        {
            return new {
                Name = this.Name
            };
        }

        // Imports
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var types = this.EdmStructuredType.NavigationProperties
                    .Select(a => a.Type)
                    .ToList();
                /*For Not-EDM types (e.g. enums with namespaces, complex types*/
                types.AddRange(this.EdmStructuredType.Properties
                    .Where(a => !a.IsEdmType)
                    .Select(a => a.Type));
                if (this.Base != null)
                    types.Add(this.Base.EdmStructuredType.Type);
                return types.Distinct();
            }
        }
        public override string Name => this.EdmStructuredType.Name;
        public override string NameSpace => this.EdmStructuredType.NameSpace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
    }
}