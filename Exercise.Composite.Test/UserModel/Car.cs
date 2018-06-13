using System;

namespace Exercise.Composite.Test.UserModel
{
    public class Car : ICompositeChild<string>
    {
        public string Color { get; set; }

        public ICompositeParent<string> Parent { get; set; }

        public string BubbleDown(string input)
        {
            return $"{input},{ToString()}";
        }

        public bool StopBubble() => false;

        public override string ToString() => $"Car: {Color}";
    }
}
