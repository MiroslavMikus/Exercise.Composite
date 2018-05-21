﻿using System;
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
            BubbleUp = () => Console.WriteLine($"Bubble up -> {nameof(Group)} : {Name}");
        }

        public string Name { get; set; }
        public List<User> Users { get; set; }

        public IEnumerable<ICompositeChild> Childs => Users;
        public Action BubbleUp { get; set; }
        public bool StopBubble() => false;
    }
}
