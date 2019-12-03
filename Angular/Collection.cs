using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class Collection : AngularRenderable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Angular.Model Model { get; private set; }
        public Angular.Service Service {get; private set;}

        public Collection(StructuredType type, Angular.Model model)
        {
            EdmStructuredType = type;
            this.Model = model;
            this.Dependencies.Add(model);
            model.SetCollection(this);
        }
        
        public void SetService(Service service)
        {
            this.Service = service;
        }
        // Imports
        public override IEnumerable<string> ImportTypes => this.Model.ExportTypes.Distinct();
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.EdmStructuredType.Name + "Collection";
        public string EntityType => this.EdmStructuredType.FullName;
        public override string NameSpace => this.EdmStructuredType.Namespace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public string ModelName => this.Model.Name;
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".collection";
    }
}