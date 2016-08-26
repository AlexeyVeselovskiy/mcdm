using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AhpDemo
{
    public static class Extensions
    {
        public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable<T>
        {
            var sorted = collection.OrderBy(x => x).ToList();

            var index = 0;
            while (index < sorted.Count)
            {
                if (!ReferenceEquals(collection[index], sorted[index]))
                {
                    var t = collection[index];
                    collection.RemoveAt(index);
                    collection.Insert(sorted.IndexOf(t), t);
                }
                else
                {
                    index++;
                }
            }
        }
    }
}
