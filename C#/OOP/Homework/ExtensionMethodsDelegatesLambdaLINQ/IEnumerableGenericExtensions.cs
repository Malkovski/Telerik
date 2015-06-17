namespace ExtensionMethodsDelegatesLambdaLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public static class IEnumerableGenericExtensions
    {
        public static T Sum<T>(this IEnumerable<T> enu) where T : IComparable<T> 
        {
            IEnumerator<T> index = enu.GetEnumerator();
            index.MoveNext();
            dynamic sum = index.Current;
            int counter = 0;

            foreach (T item in enu)
            {
                if (counter != 0)
                {
                    sum += item; 
                }

                counter++;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> enu) where T : IComparable<T> 
        {
            IEnumerator<T> index = enu.GetEnumerator();
            index.MoveNext();
            dynamic product = index.Current;
            int count = 0;

            foreach (T item in enu)
            {
                if (count != 0)
                {
                    product *= item;
                }

                count++;
            }

            return product;
        }

        public static T Average<T>(this IEnumerable<T> enu) where T : IComparable<T> 
        {
            int count = 0;

            foreach (T item in enu)
            {
                count++;	 
            }

            return (dynamic)enu.Sum() / count;
        }

        public static T Max<T>(this IEnumerable<T> enu) where T : IComparable<T> 
        {
            IEnumerator<T> index = enu.GetEnumerator();
            index.MoveNext();
            dynamic max = index.Current;

            foreach (T item in enu)
            {
                if ((dynamic)item.CompareTo(max) > 0 )
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Min<T>(this IEnumerable<T> enu) where T : IComparable<T> 
        {
            IEnumerator<T> index = enu.GetEnumerator();
            index.MoveNext();
            dynamic min = index.Current;

            foreach (T item in enu)
            {
                if ((dynamic)item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }
    }
}
