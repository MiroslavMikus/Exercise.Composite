using Exercise.Composite.CompositeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite.Test.RecrusiveNodeModel
{
    public class Node : ICompositeParent<string>, ICompositeChild<string>
    {
        public string Name { get; set; }
        public List<Node> ChildNodes { get; set; } = new List<Node>();

        #region ICompositeParent<string>
        public IEnumerable<ICompositeChild<string>> Childs => ChildNodes;

        public string BubbleUp(string input) => $"{input}{Name}";
        #endregion

        #region ICompositeChild<string>
        public ICompositeParent<string> Parent { get; set; }

        public string BubbleDown(string input) => $"{input}{Name}";

        #endregion
        public override string ToString() => Name;
        public bool StopBubble() => false;
    }

    public static class FakeStorage
    {
        public static IEnumerable<Node> ManyNodes()
        {
            Stack<string> GetNames() => new Stack<string>(new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "E", "F", "G", "H" });

            while (true)
            {
                var root = new Node { Name = "Root" };

                SimpleNode(9, root, GetNames());

                yield return root;
            }
        }

        private static Node SimpleNode(int recrusion, Node parentNode, Stack<string> names)
        {
            if (recrusion == 0) return parentNode;

            recrusion--;

            Node CreateNode() => new Node { Name = names.Pop() };

            var firstNode = CreateNode();
            var secondNode = CreateNode();

            parentNode.ChildNodes.Add(firstNode);

            parentNode.ChildNodes.Add(secondNode);

            return SimpleNode(recrusion, recrusion % 2 == 0 ? firstNode : secondNode, names);
        }
    }
}
