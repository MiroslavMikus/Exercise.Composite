using System;
using System.Collections.Generic;

namespace Exercise.Composite.TestConsole.Model
{
    public class User : ICompositeChild, ICompositeParent
    {
        public User()
        {
            (this as ICompositeChild).BubbleDown = () => Console.WriteLine($"Bubble down -> {nameof(User)} : {Name}");
            (this as ICompositeParent).BubbleUp = () => Console.WriteLine($"Bubble up -> {nameof(User)} : {Name}");
        }

        public string Name { get; set; }
        public List<Car> Cars { get; set; }

        public ICompositeParent Parent { get; set; }
        public IEnumerable<ICompositeChild> Childs => Cars;

        Action ICompositeChild.BubbleDown { get; set; }
        Action ICompositeParent.BubbleUp { get; set; }
        public bool StopBubble() => false;
    }
}
