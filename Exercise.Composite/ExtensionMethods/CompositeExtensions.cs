using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite
{
    public static class CompositeExtensions
    {
        public static void InvokeBubbleOne(this ICanBubble composite)
        {
            composite.Bubble?.Invoke();
        }

        public static void InvokeBubbleAllUp(this ICompositeChild composite)
        {
            // InvokeParent
            composite.Parent.Bubble?.Invoke();

            // if the parent is a child -> start recrusion here
            if (composite.Parent is ICompositeChild myParentIsChild)
            {
                myParentIsChild.InvokeBubbleAllUp();
            }
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

                if (child is IMultipleCompositeParent myChildIsMultipleParent)
                {
                    myChildIsMultipleParent.InvokeBubbleAllDown();
                }
            }
        }

        public static void InvokeBubbleAllDown(this IMultipleCompositeParent composite)
        {
            // Invoke all childs
            foreach (var childList in composite.MultipleChilds)
            {
                foreach (var child in childList)
                {
                    child.Bubble?.Invoke();

                    // if the child is a parent -> start recrusion here
                    if (child is IMultipleCompositeParent myChildIsParent)
                    {
                        myChildIsParent.InvokeBubbleAllDown();
                    }

                    if (child is ICompositeParent myChildIsSimpleParent)
                    {
                        myChildIsSimpleParent.InvokeBubbleAllDown();
                    }
                }
            }
        }
    }
}
