using System;
using System.Collections.Generic;

namespace Exercise.Composite
{
    public interface ICompositeParent
    {
        IEnumerable<ICompositeChild> Childs { get; }
        Action BubbleUp { get; set; }
        bool StopBubble();
    }

    public interface ICompositeParent<T>
    {
        IEnumerable<ICompositeChild<T>> Childs { get; }
        Func<T, T> Bubble { get; set; }
        bool StopBubble();
    }
}
