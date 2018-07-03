using Exercise.Composite.CompositeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite.Test.UserModel
{
    public class Group : ICompositeParent<string>
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }

        public IEnumerable<ICompositeChild<string>> Childs => Users;

        public bool StopBubbleProp { get; set; } = false;
        public bool StopBubble() => StopBubbleProp;

        public string BubbleUp(string input)
        {
            return input;
        }

        public override string ToString() => $"Group: {Name}";
    }
}
