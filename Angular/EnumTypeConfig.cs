using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using ODataApiGen.Abstracts;
using DotLiquid;
using System;

namespace ODataApiGen.Angular
{
    public class EnumMemberConfig : ILiquidizable
    {
        protected Models.EnumMember Value { get; set; }
        protected Angular.EnumTypeConfig Config { get; set; }
        public EnumMemberConfig(Models.EnumMember member, Angular.EnumTypeConfig config) {
            this.Value = member;
            this.Config = config;
        }
        public string Name => Utils.IsValidTypeScrtiptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";

        public string Type { 
            get {
                var values = new Dictionary<string, string>();
                values.Add("value", $"{this.Value.Value}");
                if (this.Name != this.Value.Name)
                    values.Add("name", $"'{this.Value.Name}'");
                var annots = this.Value.Annotations;
                if (annots.Count > 0) {
                    var json = JsonConvert.SerializeObject(annots.Select(annot => annot.ToDictionary()));
                    values.Add("annotations", $"{json}");
                }
                return $"{{{String.Join(", ", values.Select(p => $"{p.Key}: {p.Value}"))}}}";
            }
        } 
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
    }
    public class EnumTypeConfig: AngularRenderable, DotLiquid.ILiquidizable 
    {
        public Angular.Enum Enum {get; private set;}
        public EnumTypeConfig(Angular.Enum enu, ApiOptions options) : base(options) {
            this.Enum = enu;
        }
        public override string FileName => this.Enum.FileName + ".config";
        public override string Name => this.Enum.Name + "Config";
        public string EnumType => this.Enum.EdmEnumType.FullName;
        public string EdmEnumName => this.Enum.EdmEnumType.Name;
        public string EnumName => this.Enum.Name;

        public string Annotations {
            get {
                return JsonConvert.SerializeObject(this.Enum.EdmEnumType.Annotations.Select(annot => annot.ToDictionary()));
            }
        }
        public IEnumerable<Angular.EnumMemberConfig> Members {
            get {
                return this.Enum.EdmEnumType.Members.Select(member => new EnumMemberConfig(member, this));
            }
        }

        // Imports
        public override IEnumerable<string> ImportTypes => new List<string> { this.EnumType };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Namespace => this.Enum.EdmEnumType.Namespace;
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public bool Flags => this.Enum.EdmEnumType.Flags; 

        public object ToLiquid()
        {
            return new {
                Name = this.ImportedName,
                Type = this.Type,
                EnumName = this.EnumName
            };
        }
    }
}