using System.Linq;

namespace Od2Ts.Models
{
    public class NavigationProperty : Property
    {
        public string FullName { get; set; }
        public string Partner { get; set; }
        public string ReferentialConstraint { get; set; }
        public string ReferencedProperty { get; set; }
    }
}