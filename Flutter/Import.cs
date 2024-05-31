using DotLiquid;

namespace ODataApiGen.Flutter
{
    public class Import : ILiquidizable 
    {
        public IEnumerable<string> Names { get; set; }
        public Uri From { get; set; }
        public Import(IEnumerable<string> names, Uri from)
        {
            this.Names = names;
            this.From = from;
        }

        public string Path {
            get {
                var path = this.From.ToString();
                if (!path.StartsWith("../"))
                    path = $"./{path}";
                return path;
            }
        }

        public object ToLiquid()
        {
            return new {this.Path, this.Names};
        }
    }
}