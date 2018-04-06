using System.Linq;

namespace Od2Ts.Models
{
    public class Property
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsCollection { get; set; }
        public bool IsRequired { get; set; }
    }
}
