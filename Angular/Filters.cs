using System;
using System.Collections.Generic;
using System.Linq;

namespace ODataApiGen.Angular {
    public static class Filters
    {
        public static string Parameters(IEnumerable<CallableParameterConfig> parameters) {
            return string.Join(", ", parameters.Select(p => $"{p.Name}: {p.Type}"));
        }
        public static string Methodcase(string name) {
            return AngularRenderable.ToTypescriptName(name, TypeScriptElement.Method);
        }
    }
}
