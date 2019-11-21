using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using DotLiquid;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class InterfaceProperty : EntityProperty
    {
        public InterfaceProperty(ODataApiGen.Models.Property prop) : base(prop)
        {
        }
        public override string Name => Value.Name + (Value.IsNullable ? "?" : "");
        public override string Type => AngularRenderable.GetTypescriptType(Value.Type) + (Value.IsCollection ? "[]" : "");
    }
    public class Interface : Entity 
    {
        public Interface(StructuredType type) : base(type) { }

        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".interface";
        // Exports

        public override IEnumerable<Angular.EntityProperty> Properties => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => new Angular.InterfaceProperty(prop));
    }
}