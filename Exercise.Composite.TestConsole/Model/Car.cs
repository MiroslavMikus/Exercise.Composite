using System;

namespace Exercise.Composite.TestConsole.Model
{
    public class Car : ICompositeChild
    {
        public Car()
        {
            BubbleDown = () => Console.WriteLine($"Bubble down -> {nameof(Car)} Color: {Color}");
        }

        public string Color { get; set; }

        public ICompositeParent Parent { get; set; }
        public Action BubbleDown { get; set; }

        public bool StopBubble() => false;
    }
}
