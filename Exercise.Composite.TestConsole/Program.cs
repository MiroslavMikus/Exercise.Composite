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

            group.InitChildsRecrusive();


            Console.WriteLine("Root (group) invokes bubble-down");
            group.InvokeBubbleAllDown();

            Console.ReadLine();

            Console.WriteLine("Miros car invokes bubble-up");
            group.Users[0].Cars[0].InvokeBubbleAllUp();

            Console.ReadLine();
        }
    }
}
