using System;
using System.Collections.Generic;
using System.Linq;

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

        public static void InitChilds<T>(this ICompositeParent<T> composite, Action<ICompositeChild<T>> executeAfterInit = null)
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

        public static void InitChildsRecrusive<T>(this ICompositeParent<T> composite)
        {
            InitChilds(composite, child =>
            {
                if (child is ICompositeParent<T> parent)
                {
                    InitChildsRecrusive(parent);
                }
            });
        }

        /// <summary>
        /// Invokes all composites.Bubble on the way down except the current composite
        /// </summary>
        /// <param name="composite"></param>
        public static void InvokeBubbleAllDown(this ICompositeParent composite)
        {
            // Invoke all childs
            foreach (var child in composite.Childs)
            {
                if (child.StopBubble()) return;

                child.BubbleDown?.Invoke();

                // if the child is a parent -> start recrusion here
                if (child is ICompositeParent myChildIsParent)
                {
                    myChildIsParent.InvokeBubbleAllDown();
                }
            }
        }

        /// <summary>
        /// Invokes all composites.Bubble on the way down except the current composite
        /// </summary>
        /// <param name="composite"></param>
        public static void InvokeBubbleAllDown<T>(this ICompositeParent<T> composite, T input)
        {
            // Invoke all childs
            foreach (var child in composite.Childs)
            {
                if (composite.StopBubble()) return;

                var output = child.BubbleDown.Invoke(input);

                // if the child is a parent -> start recrusion here
                if (child is ICompositeParent<T> myChildIsParent)
                {
                    myChildIsParent.InvokeBubbleAllDown(output);
                }
            }
        }

        public static IEnumerable<ICompositeChild> ConcatParents(params IEnumerable<ICompositeChild>[] parents)
        {
            return parents.Aggregate((a, b) => a.Concat(b));
        }

        public static IEnumerable<ICompositeChild<T>> ConcatParents<T>(params IEnumerable<ICompositeChild<T>>[] parents)
        {
            return parents.Aggregate((a, b) => a.Concat(b));
        }
    }
}
