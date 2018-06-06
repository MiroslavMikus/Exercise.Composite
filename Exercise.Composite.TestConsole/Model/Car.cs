using System;

namespace Exercise.Composite.TestConsole.Model
{
    public class Car : ICompositeChild
    {
        public string Color { get; set; }

        public ICompositeParent Parent { get; set; }

        public void BubbleDown()
        {
            Console.WriteLine($"Bubble down -> {nameof(Car)} Color: {Color}");
        }

        public bool StopBubble() => false;
    }
}
