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
        public bool IsCollection { get; set; }
    }
}