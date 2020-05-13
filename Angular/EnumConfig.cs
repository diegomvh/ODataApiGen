using System.Collections.Generic;
using System.Linq;
using System;
using ODataApiGen.Models;
using Newtonsoft.Json;
using System.IO;

namespace ODataApiGen.Angular
{
    public class EnumConfig: AngularRenderable, DotLiquid.ILiquidizable 
    {
        public Models.EnumType EdmEnumType {get; private set;}
        public EnumConfig(EnumType type) {
            this.EdmEnumType = type;
        }
        public override string FileName => this.EdmEnumType.Name.ToLower() + ".enum.config";
        public override string Name => this.EdmEnumType.Name + "EnumConfig";
        public string EnumType => this.EdmEnumType.FullName;
        public string EnumName => this.EdmEnumType.Name;

        public string EnumAnnotations {
            get {
                return JsonConvert.SerializeObject(this.EdmEnumType.Annotations.Select(annot => annot.ToDictionary()));
            }
        }

        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { this.EnumType };
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string NameSpace => this.EdmEnumType.Namespace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public override bool Overwrite => true; 
        public bool Flags => this.EdmEnumType.Flags; 

        public object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                EnumType = this.EnumType
            };
        }
    }
}