using System;

namespace Od2Ts.Interfaces
{
    public interface IHasUri : IRenderableElement
    {
        Uri Uri { get; }
    }
}
