using System;
using System.Collections.Generic;

namespace Exercise.Composite
{
    public interface ICompositeParent
    {
        IEnumerable<ICompositeChild> Childs { get; }
        Action Bubble { get; set; }
    }

    public interface ICompositeParent<T>
    {
        IEnumerable<ICompositeChild<T>> Childs { get; }
        Func<T, T> Bubble { get; set; }
    }
}
