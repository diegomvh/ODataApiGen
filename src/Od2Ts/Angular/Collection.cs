using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class Collection : AngularRenderable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Model Model { get; private set; }
        public Angular.Service Service {get; private set;}

        public Collection(StructuredType type)
        {
            EdmStructuredType = type;
        }
        public void SetModel(Model model)
        {
            this.Model = model;
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
        public override string NameSpace => this.EdmStructuredType.NameSpace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public string ModelName => this.Model.Name;
        public override string Render()
        {
            return "";
        }

        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".collection";
    }
}