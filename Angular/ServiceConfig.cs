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
        public Models.EntitySet EdmEntitySet { get; private set; }
        public Models.Singleton EdmSingleton { get; private set; }
        public ServiceConfig(EntitySet type) {
            EdmEntitySet = type;
        }
        public ServiceConfig(Singleton singleton) {
            EdmSingleton = singleton;
        }
        public override string FileName => this.ServiceName.ToLower() + ".service.config";
        public override string Name => this.ServiceName + "ServiceConfig";

        public string Annotations {
            get {
                var annotations = this.EdmEntitySet != null ? this.EdmEntitySet.Annotations : this.EdmSingleton.Annotations;
                return JsonConvert.SerializeObject(annotations.Select(annot => annot.ToDictionary()), Formatting.Indented);
            }
        }

        public string ServiceType => (this.EdmEntitySet != null? this.EdmEntitySet.FullName : this.EdmSingleton.FullName);
        public string ServiceName {
            get {
                var name = this.EdmEntitySet != null? this.EdmEntitySet.Name : this.EdmSingleton.Name;
                return name.Substring(0, 1).ToUpper() + name.Substring(1);
            }
        }
        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { };
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string NameSpace => (this.EdmEntitySet != null? this.EdmEntitySet.Namespace : this.EdmSingleton.Namespace);
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
    }
}