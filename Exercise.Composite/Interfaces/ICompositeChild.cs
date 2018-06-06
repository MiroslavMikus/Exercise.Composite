using System;
using System.Collections.Generic;

namespace Exercise.Composite
{
    public interface ICompositeChild
    {
        ICompositeParent Parent { get; set; }
        void BubbleDown();
        bool StopBubble();
    }

    public interface ICompositeChild<T>
    {
        ICompositeParent<T> Parent { get; set; }
        T BubbleDown(T input);
        bool StopBubble();
    }
}
