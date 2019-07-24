using System;
using System.Linq;

namespace Od2Ts.Models
{
    public class Property
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsEdmType { get { return !System.String.IsNullOrWhiteSpace(Type) && Type.StartsWith("Edm."); } }
        public bool IsCollection { get; set; }
        public bool IsNullable { get; set; }
        public string MaxLength { get; set; }
        public string DisplayName { get; set; }
    }
}
