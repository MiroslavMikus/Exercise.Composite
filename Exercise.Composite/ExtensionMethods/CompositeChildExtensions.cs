namespace Exercise.Composite
{
    public static class CompositeChildExtensions
    {

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
    }
}
