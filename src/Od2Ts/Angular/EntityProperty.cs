using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;

namespace Od2Ts.Angular
{
    public class EntityProperty : ILiquidizable
    {
        private Models.Property Value { get; set; }
        public EntityProperty(Od2Ts.Models.Property prop)
        {
            this.Value = prop;
        }
        public IEnumerable<string> Name { get; set; }

        public string Type => EntityProperty.GetTypescriptType(Value.Type);
        public object ToLiquid()
        {
            return new
            {
                Name = Value.Name + (Value.IsNullable ? "?" : ""),
                Type = this.Type + (Value.IsCollection ? "[]" : "")
            };
        }

        public static string GetTypescriptType(string type) {
                if (String.IsNullOrWhiteSpace(type))
                    return "any";
                switch (type)
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
                            return type.Contains(".") && !type.StartsWith("Edm") ?
                                type.Split('.').Last(a => !String.IsNullOrWhiteSpace(a)) : "any";
                        }
                }

        }
    }
}