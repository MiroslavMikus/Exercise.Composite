using System;
using System.Collections.Generic;

namespace Exercise.Composite.TestConsole.Model
{
    public class User : ICompositeChild, ICompositeParent
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }

        public ICompositeParent Parent { get; set; }
        public IEnumerable<ICompositeChild> Childs => Cars;

        public void BubbleUp() => Console.WriteLine($"Bubble up -> {nameof(User)} : {Name}");
        public bool StopBubble() => false;

        void ICompositeChild.BubbleDown() => Console.WriteLine($"Bubble down -> {nameof(User)} : {Name}");

        public override string ToString() => $"User: {Name}";

    }
}
