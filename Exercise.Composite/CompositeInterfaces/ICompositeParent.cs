using System.Collections.Generic;

namespace Exercise.Composite.CompositeInterfaces
{
    public interface ICompositeParent
    {
        IEnumerable<ICompositeChild> Childs { get; }
        void BubbleUp();
        bool StopBubble();
    }

    public interface ICompositeParent<T>
    {
        IEnumerable<ICompositeChild<T>> Childs { get; }
        T BubbleUp(T input);
        bool StopBubble();
    }
}
