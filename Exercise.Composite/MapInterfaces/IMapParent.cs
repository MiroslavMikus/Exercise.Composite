using System.Collections.Generic;

namespace Exercise.Composite.MapInterfaces
{
    public interface IMapParent<T>
    {
        ICollection<IMapChild<T>> Children { get; set; }
        T BubbleUpPipe(T input);
        void BubbleUp(T input);
        bool StopBubble();
    }

    public interface IMap<T> : IMapParent<T>, IMapChild<T>
    {
    }
}