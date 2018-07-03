using Exercise.Composite.MapInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite.MapExtensions
{
    public static class MapChildExtensions
    {
        public static void ExecuteOnParentRecrusive<T>(this IMapChild<T> map, Action<IMapParent<T>, IMapChild<T>> action)
        {
            foreach (var parent in map.Parents)
            {
                action(parent, map);

                if (parent is IMapChild<T> alsoChild)
                {
                    alsoChild.ExecuteOnParentRecrusive(action);
                }
            }
        }

        public static void InitParentsRecrusive<T>(this IMapChild<T> map)
        {
            map.ExecuteOnParentRecrusive((parent, child) => parent.Children.Add(child));
        }
    }

    public static class MapParentExtensions
    {
        public static void ExecuteOnParentRecrusive<T>(this IMapParent<T> map, Action<IMapParent<T>, IMapChild<T>> action)
        {
            foreach (var child in map.Children)
            {
                action(map, child);

                if (child is IMapParent<T> alsoParent)
                {
                    alsoParent.ExecuteOnParentRecrusive(action);
                }
            }
        }

        public static void InitChildsRecrusive<T>(this IMapParent<T> map)
        {
            map.ExecuteOnParentRecrusive((parent, child) => child.Parents.Add(parent));
        }
    }
}
