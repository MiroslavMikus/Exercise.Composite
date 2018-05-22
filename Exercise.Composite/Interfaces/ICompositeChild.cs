using System;
using System.Collections.Generic;

namespace Exercise.Composite
{
    public interface ICompositeChild
    {
        ICompositeParent Parent { get; set; }
        Action BubbleDown { get; set; }
        bool StopBubble();
    }

    public interface ICompositeChild<T>
    {
        ICompositeParent<T> Parent { get; set; }
        Func<T,T> BubbleDown { get; set; }
        bool StopBubble();
    }
}
