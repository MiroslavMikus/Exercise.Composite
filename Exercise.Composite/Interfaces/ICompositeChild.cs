using System;

namespace Exercise.Composite
{
    public interface ICompositeChild
    {
        ICompositeParent Parent { get; set; }

        /// <summary>
        /// Child composite can bubble up with <see cref="InvokeBubbleAllUp"/>
        /// </summary>
        Action Bubble { get; set; }
    }
}
