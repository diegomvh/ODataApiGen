using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;

namespace Od2Ts.Angular
{
    public class Property : ILiquidizable
    {
        private Models.Property Value { get; set; }
        public Property(Od2Ts.Models.Property prop)
        {
            this.Value = prop;
        }
        public IEnumerable<string> Name { get; set; }

        public string Type
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Value.Type))
                    return "any";
                switch (Value.Type)
                {
                    case "Edm.String":
                    case "Edm.Duration":
                    case "Edm.Guid":
                    case "Edm.Binary":
                        return "string";
                    case "Edm.Int16":
                    case "Edm.Int32":
                    case "Edm.Int64":
                    case "Edm.Double":
                    case "Edm.Decimal":
                    case "Edm.Single":
                    case "Edm.Byte":
                        return "number";
                    case "Edm.Boolean":
                        return "boolean";
                    case "Edm.DateTimeOffset":
                        return "Date";
                    default:
                        {
                            return Value.Type.Contains(".") && !Value.Type.StartsWith("Edm") ?
                                Value.Type.Split('.').Last(a => !String.IsNullOrWhiteSpace(a)) : "any";
                        }
                }
            }
        }

        public object ToLiquid()
        {
            return new
            {
                Name = Value.Name + (Value.IsNullable ? "?" : ""),
                Type = this.Type + (Value.IsCollection ? "[]" : "")
            };
        }
    }
}