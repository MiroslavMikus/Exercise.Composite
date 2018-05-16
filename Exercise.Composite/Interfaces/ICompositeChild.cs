namespace Exercise.Composite
{
    public interface ICompositeChild : ICanBubble
    {
        ICompositeParent Parent { get; set; }
    }
}
