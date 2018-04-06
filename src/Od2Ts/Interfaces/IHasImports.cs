using System;
using System.Collections.Generic;
using Od2Ts.Abstracts;

namespace Od2Ts.Interfaces
{
    public interface IHasImports : IHasUri
    {
        IEnumerable<Import> Imports { get; }
    }
}
