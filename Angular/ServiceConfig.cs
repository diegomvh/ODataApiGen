using System.Collections.Generic;
using System.Linq;
using System;
using ODataApiGen.Models;
using Newtonsoft.Json;
using System.IO;

namespace ODataApiGen.Angular
{
    public class ServiceConfig: AngularRenderable, DotLiquid.ILiquidizable 
    {
        public Angular.Service Service { get; private set; }
        public ServiceConfig(Angular.Service service) {
            Service = service;
        }
        public override string FileName => this.Service.FileName + ".config";
        public override string Name => this.ServiceName + "Config";

        public string Annotations {
            get {
                var annotations = this.Service.Annotations;
                return JsonConvert.SerializeObject(annotations.Select(annot => annot.ToDictionary()), Formatting.Indented);
            }
        }
        public string ServiceName => this.Service.Name;
        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { };
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Namespace => this.Service.Namespace;
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                ServiceName = this.ServiceName
            };
        }
    }
}