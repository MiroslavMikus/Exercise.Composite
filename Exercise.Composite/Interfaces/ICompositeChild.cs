using System;
using System.Collections.Generic;

namespace Exercise.Composite
{
    public interface ICompositeChild
    {
        ICompositeParent Parent { get; set; }
        Action Bubble { get; set; }
    }

    public interface ICompositeChild<T>
    {
        ICompositeParent<T> Parent { get; set; }
        Func<T,T> Bubble { get; set; }
    }
}
