using System;
using System.Collections.Generic;

namespace Exercise.Composite
{
    public interface ICompositeParent
    {
        IEnumerable<ICompositeChild> Childs { get; }

        /// <summary>
        /// Parent composite can bubble down with <see cref="InvokeBubbleAllUp"/>
        /// </summary>
        Action Bubble { get; set; }
    }
}
