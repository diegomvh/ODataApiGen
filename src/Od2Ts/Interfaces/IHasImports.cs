using System;
using System.Collections.Generic;

namespace Od2Ts.Interfaces
{
    public interface IHasImports : IHasUri
    {
        IEnumerable<Uri> Imports { get; }
    }
}
