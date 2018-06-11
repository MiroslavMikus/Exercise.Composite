using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise.Composite
{
    public static class CompositeParentExtensions
    {
        /// <summary>
        /// Edit or update all composites in the tree
        /// </summary>
        /// <param name="composite">Composite to start from</param>
        /// <param name="action">Action will be executed on the current parent and child pair</param>
        public static void ExecuteOnChildRecrusive(this ICompositeParent composite, Action<ICompositeParent, ICompositeChild> action)
        {
            foreach (var child in composite.Childs)
            {
                action(composite, child);

                if (child is ICompositeParent parent)
                {
                    parent.ExecuteOnChildRecrusive(action);
                }
            }
        }

        /// <summary>
        /// Edit or update all composites in the tree
        /// </summary>
        /// <param name="composite">Composite to start from</param>
        /// <param name="action">Action will be executed on the current parent and child pair</param>
        public static void ExecuteOnChildRecrusive<T>(this ICompositeParent<T> composite, Action<ICompositeParent<T>, ICompositeChild<T>> action)
        {
            foreach (var child in composite.Childs)
            {
                action(composite, child);

                if (child is ICompositeParent<T> parent)
                {
                    parent.ExecuteOnChildRecrusive(action);
                }
            }
        }

        /// <summary>
        /// Cretes connection between paren and child composite -> set the parent field for all childs in recrusion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="composite">Root composite</param>
        public static void InitChildsRecrusive(this ICompositeParent composite)
        {
            composite.ExecuteOnChildRecrusive((parent, child) => child.Parent = parent);
        }

        /// <summary>
        /// Cretes connection between paren and child composite -> set the parent field for all childs in recrusion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="composite">Root composite</param>
        public static void InitChildsRecrusive<T>(this ICompositeParent<T> composite)
        {
            composite.ExecuteOnChildRecrusive((parent, child) => child.Parent = parent);
        }

        /// <summary>
        /// Invokes BubbleDown on the way down except the current composite
        /// </summary>
        /// <param name="composite"></param>
        public static void InvokeBubbleDown(this ICompositeParent composite)
        {
            // Invoke all childs
            foreach (var child in composite.Childs)
            {
                if (composite.StopBubble()) return;

                child.BubbleDown();

                // if the child is a parent -> start recrusion here
                if (child is ICompositeParent myChildIsParent)
                {
                    myChildIsParent.InvokeBubbleDown();
                }
            }
        }

        /// <summary>
        /// Invokes BubbleDown on the way down except the current composite
        /// </summary>
        /// <param name="composite"></param>
        public static T InvokeBubbleDown<T>(this ICompositeParent<T> composite, T input)
        {
            // Invoke all childs
            foreach (var child in composite.Childs)
            {
                if (composite.StopBubble()) return input;

                input = child.BubbleDown(input);

                // if the child is a parent -> start recrusion here
                if (child is ICompositeParent<T> myChildIsParent)
                {
                    input = myChildIsParent.InvokeBubbleDown(input);
                }
            }
            return input;
        }

        public static IEnumerable<T> InvokeBubbleDownNonCummulative<T>(this ICompositeParent<T> composite, T input)
        {
            List<ICompositeChild<T>> bottomChildren = new List<ICompositeChild<T>>();

            composite.ExecuteOnChildRecrusive((parent, child) =>
            {
                if (!(child is ICompositeParent<T>))
                {
                    bottomChildren.Add(child);
                }
            });

            foreach (var child in bottomChildren)
            {
                var stack = child.BuildStackToRoot();

                yield return stack.Aggregate(input, (accumulate, comp) => comp.BubbleDown(accumulate));
            }
        }

        /// <summary>
        /// Allows composite parent use multiple child collections.
        /// </summary>
        /// <param name="parents"></param>
        /// <returns></returns>
        public static IEnumerable<ICompositeChild> ConcatChildren(params IEnumerable<ICompositeChild>[] parents)
        {
            return parents.Aggregate((a, b) => a.Concat(b));
        }

        /// <summary>
        /// Allows composite parent use multiple child collections.
        /// </summary>
        /// <param name="parents"></param>
        /// <returns></returns>
        public static IEnumerable<ICompositeChild<T>> ConcatChildren<T>(params IEnumerable<ICompositeChild<T>>[] parents)
        {
            return parents.Aggregate((a, b) => a.Concat(b));
        }

        /// <summary>
        /// Creates simple view on your composite tree. Very usefull for debugging purposes.
        /// </summary>
        /// <param name="composite">Root Composite</param>
        /// <param name="depth"></param>
        /// <returns>Vizualized tree in a string format</returns>
        public static string VizualizeTree(this ICompositeParent composite, int depth = 0)
        {
            var result = new StringBuilder();

            if (depth == 0)
            {
                result.AppendLine(composite.ToString());
                depth++;
            }

            foreach (var child in composite.Childs)
            {
                result.AppendLine($" {new string('-', depth)} {child.ToString()}");

                if (child is ICompositeParent parent)
                {
                    result.Append(parent.VizualizeTree(depth + 1));

                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Creates simple view on your composite tree. Very usefull for debugging purposes.
        /// </summary>
        /// <param name="composite">Root Composite</param>
        /// <param name="depth"></param>
        /// <returns>Vizualized tree in a string format</returns>
        public static string VizualizeTree<T>(this ICompositeParent<T> composite, int depth = 0)
        {
            var result = new StringBuilder();

            if (depth == 0)
            {
                result.AppendLine(composite.ToString());
                depth++;
            }

            foreach (var child in composite.Childs)
            {
                result.AppendLine($" {new string('-', depth)} {child.ToString()}");

                if (child is ICompositeParent<T> parent)
                {
                    result.Append(parent.VizualizeTree(depth + 1));
                }
            }
            return result.ToString();
        }
    }
}
