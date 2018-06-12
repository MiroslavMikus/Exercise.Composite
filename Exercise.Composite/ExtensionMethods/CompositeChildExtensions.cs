using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Composite
{
    public static class CompositeChildExtensions
    {
        /// <summary>
        /// Invokes all composites. Bubble on the way up except the current composite.
        /// </summary>
        /// <param name="composite"></param>
        /// <exception cref="ArgumentNullException">
        /// Will be thrown if the Composite parent is null.
        /// </exception>
        public static void InvokeBubbleUp(this ICompositeChild composite)
        {
            if (composite.StopBubble()) return;

            // validation
            if (composite.Parent == null)
            {
                // detect recrusive-composite root ->
                // composite child is also composite parent
                // one of the child elements hast the same type
                if (composite is ICompositeParent parent &&
                    parent.Childs.Any(a => a.GetType() == composite.GetType()))
                {
                    return;
                }
                else
                {
                    throw new ArgumentNullException($"{nameof(CompositeChildExtensions)}.{nameof(InvokeBubbleUp)} says: Composite parent cant be null!");
                }
            }

            // Invoke Parent
            composite.Parent.BubbleUp();

            // if the parent is a child -> start recrusion here
            if (composite.Parent is ICompositeChild myParentIsChild)
            {
                myParentIsChild.InvokeBubbleUp();
            }
        }

        /// <summary>
        /// Invokes all composites. Bubble on the way up except the current composite.
        /// Execution is equal to pipeline logic.
        /// </summary>
        /// <param name="composite"></param>
        /// <exception cref="ArgumentNullException">
        /// Will be thrown if the Composite parent is null.
        /// </exception>
        public static T InvokeBubbleUp<T>(this ICompositeChild<T> composite, T input)
        {
            if (composite.StopBubble()) return input;

            // validation
            if (composite.Parent == null)
            {
                // detect recrusive-composite root ->
                // composite child is also composite parent
                // one of the child elements hast the same type
                if (composite is ICompositeParent<T> parent &&
                    parent.Childs.Any(a => a.GetType() == composite.GetType()))
                {
                    return input;
                }
                else
                {
                    throw new ArgumentNullException($"Composite parent cant be null!");
                }
            }

            // Invoke Parent
            input = composite.Parent.BubbleUp(input);

            // if the parent is a child -> start recrusion here
            if (composite.Parent is ICompositeChild<T> myParentIsChild)
            {
                myParentIsChild.InvokeBubbleUp(input);
            }

            return input;
        }

        /// <summary>
        /// Returns the root of the current tree.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="composite">Current composite</param>
        /// <param name="filter">Parent conditions. If these conditions are not met, or filter is null, the root element will be returned.</param>
        /// <returns></returns>
        public static ICompositeParent<T> GetRootComponent<T>(this ICompositeChild<T> composite, Func<ICompositeParent<T>, bool> filter = null)
        {
            if (filter?.Invoke(composite.Parent) == true)
                return composite.Parent;

            if (composite.Parent is ICompositeChild<T> child)
            {
                return child.GetRootComponent<T>();
            }
            else
            {
                return composite.Parent;
            }
        }

        /// <summary>
        /// Returns the root of the current tree.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="composite">Current composite</param>
        /// <param name="filter">Parent conditions. If these conditions are not met, or filter is null, the root element will be returned.</param>
        /// <returns></returns>
        public static ICompositeParent GetRootComponent(this ICompositeChild composite, Func<ICompositeParent, bool> filter = null)
        {
            if (filter?.Invoke(composite.Parent) == true)
            {
                return composite.Parent;
            }

            if (composite.Parent is ICompositeChild child)
            {
                return child.GetRootComponent();
            }
            else
            {
                return composite.Parent;
            }
        }

        public static IEnumerable<ICompositeChild<T>> GetSibling<T>(this ICompositeChild<T> composite, Func<ICompositeChild<T>, bool> filter = null)
        {
            return composite.Parent.Childs.Where(filter ?? (a => true)).Where(a => a != composite);
        }

        public static IEnumerable<ICompositeChild> GetSibling(this ICompositeChild composite, Func<ICompositeChild, bool> filter = null)
        {
            return composite.Parent.Childs.Where(filter ?? (a => true)).Where(a => a != composite);
        }

        /// <summary>
        /// Iterates from the current child composite to the root child composite and collect all references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="composite">The current composite child.</param>
        /// <param name="currentStack"></param>
        /// <returns>Stack where the first element is the current child and last is the composite root.</returns>
        public static Stack<ICompositeChild<T>> BuildStackToRoot<T>(this ICompositeChild<T> composite, Stack<ICompositeChild<T>> currentStack = null)
        {
            var stack = currentStack ?? new Stack<ICompositeChild<T>>();

            stack.Push(composite);

            if (composite.Parent is ICompositeChild<T> child) 
            {
                return BuildStackToRoot(child, stack);
            }
            else
            {
                return stack;
            }
        }

        /// <summary>
        /// Iterates from the current child composite to the root child composite and collect all references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="composite">The current composite child.</param>
        /// <param name="currentStack"></param>
        /// <returns>Stack where the first element is the current child and last is the composite root.
        public static Stack<ICompositeChild> BuildStackToRoot(this ICompositeChild composite, Stack<ICompositeChild> currentStack = null)
        {
            var stack = currentStack ?? new Stack<ICompositeChild>();

            stack.Push(composite);

            if (composite.Parent is ICompositeChild child)
            {
                return BuildStackToRoot(child, stack);
            }
            else
            {
                return stack;
            }
        }
    }
}
