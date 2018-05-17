using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite
{
    public static class CompositeParentExtensions
    {
        public static void InitChilds(this ICompositeParent composite, Action<ICompositeChild> executeAfterInit = null) 
        {
            foreach (var child in composite.Childs)
            {
                child.Parent = composite;

                executeAfterInit?.Invoke(child);
            }
        }

        public static void InitChildsRecrusive(this ICompositeParent composite)
        {
            InitChilds(composite, child =>
            {
                if (child is ICompositeParent parent)
                {
                    InitChildsRecrusive(parent);
                }
            });
        }
        public static void InvokeBubbleAllDown(this ICompositeParent composite)
        {
            // Invoke all childs
            foreach (var child in composite.Childs)
            {
                child.Bubble?.Invoke();

                // if the child is a parent -> start recrusion here
                if (child is ICompositeParent myChildIsParent)
                {
                    myChildIsParent.InvokeBubbleAllDown();
                }
            }
        }

        public static IEnumerable<ICompositeParent> ConcatParents(params IEnumerable<ICompositeParent>[] parents)
        {
            return parents.Aggregate((a, b) => a.Concat(b));
        }
    }
}
