using System.Collections.Generic;

namespace Exercise.Composite
{
    public interface ICompositeParent : ICanBubble
    {
        IEnumerable<ICompositeChild> Childs { get; set; }
    }
}
