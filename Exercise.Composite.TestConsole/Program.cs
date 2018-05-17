using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var group = FakeStorage.GetSimpleGroup();

            group.InvokeBubbleAllDown();

            Console.ReadLine();

            group.Users[0].Cars[0].InvokeBubbleAllUp();

            Console.ReadLine();
        }
    }
}
