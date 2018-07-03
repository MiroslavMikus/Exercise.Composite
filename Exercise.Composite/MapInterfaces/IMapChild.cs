using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite.MapInterfaces
{
    public interface IMapChild<T>
    {
        ICollection<IMapParent<T>> Parents { get; set; }
        T BubbleDownPipe(T input);
        void BubbleDown(T input);
        bool StopBubble();
    }
}
