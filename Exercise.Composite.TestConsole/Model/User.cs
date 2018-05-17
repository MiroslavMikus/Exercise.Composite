using System;
using System.Collections.Generic;

namespace Exercise.Composite.TestConsole.Model
{
    public class User : ICompositeChild, ICompositeParent
    {
        public User()
        {
            (this as ICompositeChild).Bubble = () => Console.WriteLine($"Bubble down -> {nameof(User)} Name: {Name}");
            (this as ICompositeParent).Bubble = () => Console.WriteLine($"Bubble up -> {nameof(User)} Name: {Name}");
        }

        public string Name { get; set; }
        public List<Car> Cars { get; set; }

        public ICompositeParent Parent { get; set; }
        public IEnumerable<ICompositeChild> Childs => Cars;

        Action ICompositeChild.Bubble { get; set; }
        Action ICompositeParent.Bubble { get; set; }
    }
}
