using System.Collections.Generic;
using System.Linq;
using System;
using ODataApiGen.Models;
using Newtonsoft.Json;
using System.IO;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class EntitySetConfig: AngularRenderable, DotLiquid.ILiquidizable 
    {
        public Angular.Service Service { get; private set; }
        public EntitySetConfig(Angular.Service service, ApiOptions options) : base(options) {
            Service = service;
            this.AddDependency(service);
        }
        public override string FileName => this.Service.FileName + ".config";
        public override string Name => Utils.ToTypescriptName(this.Service.EntitySetName, TypeScriptElement.Class) + "Config";

        public string Annotations {
            get {
                var annotations = this.Service.Annotations;
                return JsonConvert.SerializeObject(annotations.Select(annot => annot.ToDictionary()), Formatting.Indented);
            }
        }
        public string EntitySetName => this.Service.EntitySetName;
        public string EntityType => this.Service.EntityType;
        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Namespace => this.Service.Namespace;
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public object ToLiquid()
        {
            return new {
                Name = this.ImportedName,
                Type = this.Type,
                EntitySetName = this.EntitySetName,
                EntityType = this.EntityType,
                Service = new {
                    Name = this.Service.Name,
                }
            };
        }
    }
}