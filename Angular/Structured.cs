using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using DotLiquid;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public abstract class StructuredProperty : ILiquidizable
    {
        protected Models.Property Value { get; set; }
        public StructuredProperty(ODataApiGen.Models.Property prop)
        {
            this.Value = prop;
        }
        public abstract string Name { get; }

        public abstract string Type {get;}
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
    }
    public abstract class Structured : AngularRenderable, DotLiquid.ILiquidizable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Structured(StructuredType type)
        {
            EdmStructuredType = type;
        }
        public Angular.Service Service {get; private set;}

        public Structured Base { get; private set; }
        public void SetBase(Structured b)
        {
            this.Base = b;
        }

        public void SetService(Service service)
        {
            this.Service = service;
        }

        // Imports
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var types = new List<string>();
                if (this.EdmStructuredType is EntityType)
                    types.AddRange((this.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
                /*For Not-EDM types (e.g. enums with namespaces, complex types*/
                types.AddRange(this.EdmStructuredType.Properties
                    .Where(a => !a.IsEdmType)
                    .Select(a => a.Type));
                types.AddRange(this.EdmStructuredType.Actions.Select(a => a.Type));
                types.AddRange(this.EdmStructuredType.Functions.Select(a => a.Type));
                if (this.Base != null)
                    types.Add(this.Base.EdmStructuredType.FullName);
                return types.Distinct();
            }
        }
        public string EntityType => this.EdmStructuredType.FullName;
        public override string NameSpace => this.EdmStructuredType.Namespace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public abstract IEnumerable<Angular.StructuredProperty> Properties {get;} 

        public abstract object ToLiquid();
    }
}