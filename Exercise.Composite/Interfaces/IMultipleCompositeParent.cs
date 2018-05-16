using System.Collections.Generic;

namespace Exercise.Composite
{
    public interface IMultipleCompositeParent : ICanBubble
    {
        IEnumerable<IEnumerable<ICompositeChild>> MultipleChilds { get; set; }
    }
}
