using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite.TestConsole.Model
{
    public class Group : ICompositeParent
    {
        public Group()
        {
            Bubble = () => Console.WriteLine($"Bubble up -> {nameof(Group)} Name: {Name}");
        }

        public string Name { get; set; }
        List<User> Users { get; set; }

        public IEnumerable<ICompositeChild> Childs => Users;
        public Action Bubble { get; set; }
    }

    public class User : ICompositeChild, ICompositeParent
    {
        public User()
        {
            (this as ICompositeChild).Bubble = () => Console.WriteLine($"Bubble up -> {nameof(User)} Name: {Name}");
            (this as ICompositeParent).Bubble = () => Console.WriteLine($"Bubble down -> {nameof(User)} Name: {Name}");
        }

        public string Name { get; set; }
        List<Car> Cars { get; set; }

        public ICompositeParent Parent { get; set; }
        public IEnumerable<ICompositeChild> Childs => Cars;

        Action ICompositeChild.Bubble { get; set; }
        Action ICompositeParent.Bubble { get; set; }
    }

    public class Car : ICompositeChild
    {
        public Car()
        {
            Bubble = () => Console.WriteLine($"Bubble up -> {nameof(User)} Name: {Color}");
        }

        public string Color { get; set; }

        public ICompositeParent Parent { get; set; }
        public Action Bubble { get; set; }
    }
}
