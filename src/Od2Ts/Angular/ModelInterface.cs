using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ModelInterface : Model
    {
        public ModelInterface(StructuredType type) : base(type)
        {
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".interface";
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();

        public IEnumerable<Angular.EntityProperty> Properties => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => new Angular.EntityProperty(prop));

        public override string Render()
        {
            return "";
        }
    }
}