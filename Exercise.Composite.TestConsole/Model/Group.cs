using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite.TestConsole.Model
{
    public class Group : ICompositeParent
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }

        public IEnumerable<ICompositeChild> Childs => Users;
        public bool StopBubble() => false;

        void ICompositeParent.BubbleUp()
        {
            Console.WriteLine($"Bubble up -> {nameof(Group)} : {Name}");
        }
    }
}
