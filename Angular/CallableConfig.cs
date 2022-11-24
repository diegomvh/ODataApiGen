using System.Collections.Generic;
using System.Linq;
using System;
using DotLiquid;
using System.Text.Json;

namespace ODataApiGen.Angular
{
    public class CallableParameterConfig : ILiquidizable
    {
        protected Models.Parameter Value { get; set; }
        public CallableParameterConfig(Models.Parameter property) {
            this.Value = property;
        }
        public string Name => Value.Name;

        public string Type { 
            get {
                var values = new Dictionary<string, string>();
                values.Add("type", $"'{this.Value.Type}'");
                if (this.Value.IsCollection)
                    values.Add("collection", "true");
                if (!this.Value.Nullable)
                    values.Add("nullable", "false");
                var annots = this.Value.Annotations;
                if (annots.Count > 0)
                {
                    var json = JsonSerializer.Serialize(annots.Select(annot => annot.ToDictionary()));
                    values.Add("annotations", $"{json}");
                }
                return $"{{{String.Join(", ", values.Select(p => $"{p.Key}: {p.Value}"))}}}";
            }
        } 
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
    }
    public class CallableConfig : DotLiquid.ILiquidizable 
    {
        public Models.Callable Callable {get; private set;}
        public string Name => this.Callable.Name;
        public CallableConfig(Models.Callable callable) {
            this.Callable = callable;
        }

        public IEnumerable<Angular.CallableParameterConfig> Parameters {
            get {
                return this.Callable.Parameters.ToList().Select(param => new CallableParameterConfig(param));
            }
        }

    public object ToLiquid()
    {
        return new {
            Name = this.Name,
            HasPath = !String.IsNullOrWhiteSpace(this.Callable.EntitySetPath),
            EntitySetPath = this.Callable.EntitySetPath,
            HasParameters = this.Parameters.Count() > 0,
            Parameters = this.Parameters,
            Bound = this.Callable.IsBound,
            Composable = this.Callable.IsComposable,
            ReturnType = this.Callable.ReturnType,
            ReturnsCollection = this.Callable.ReturnsCollection
        };
    }
  }
}