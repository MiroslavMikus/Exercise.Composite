namespace Exercise.Composite
{
    public static class CompositeChildExtensions
    {
        /// <summary>
        /// Invokes all composites.Bubble on the way up except the current composite
        /// </summary>
        /// <param name="composite"></param>
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

        /// <summary>
        /// Invokes all composites.Bubble on the way up except the current composite
        /// </summary>
        /// <param name="composite"></param>
        public static void InvokeBubbleAllUp<T>(this ICompositeChild<T> composite, T input)
        {
            // InvokeParent
            var output = composite.Parent.Bubble.Invoke(input);

            // if the parent is a child -> start recrusion here
            if (composite.Parent is ICompositeChild<T> myParentIsChild)
            {
                myParentIsChild.InvokeBubbleAllUp(output);
            }
        }
    }
}
