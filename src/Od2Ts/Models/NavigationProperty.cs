using System.Linq;

namespace Od2Ts.Models
{
    public class NavigationProperty
    {
        public string Name => FullName.Split('.').Last();
        public string FullName { get; set; }
        public string ReferentialConstraint { get; set; }
        public string ReferencedProperty { get; set; }
        public string Type { get; set; }
        public string TypescriptType { get { return this.Type.Split('.').Last(); } }
        public bool IsCollection { get; set; }

        public string AsField() {
            return $"{this.Name}: {this.TypescriptType}" + (this.IsCollection ? "[]" : "");
        }
    }
}