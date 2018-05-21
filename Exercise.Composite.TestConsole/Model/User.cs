using System;
using System.Collections.Generic;

namespace Exercise.Composite.TestConsole.Model
{
    public class User : ICompositeChild, ICompositeParent
    {
        public User()
        {
            BubbleDown = () => Console.WriteLine($"Bubble down -> {nameof(User)} : {Name}");
            BubbleUp = () => Console.WriteLine($"Bubble up -> {nameof(User)} : {Name}");
        }

        public string Name { get; set; }
        public List<Car> Cars { get; set; }

        public ICompositeParent Parent { get; set; }
        public IEnumerable<ICompositeChild> Childs => Cars;

        public Action BubbleDown { get; set; }
        public Action BubbleUp { get; set; }
        public bool StopBubble() => false;
    }
}
