using System.Collections.Generic;
using System.Linq;

namespace Task_03
{
    public static class FindInArr
    {
        delegate List<int> FindMethod(int item, Compare del);

        public static List<int> FindEqual(this int[] arr, int item)
        {
            List<int> result = new List<int>();
            foreach (int t in arr)
            {
                if (t == item)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public delegate bool Compare(int item1, int item2);
        public static List<int> FindEqualThrouDel(this int[] arr, int item, Compare del)
        {
            List<int> result = new List<int>();
            foreach (int t in arr)
            {
                if (del(t, item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static List<int> FindEqualLinq(this int[] arr, int item)
        {
            List<int> result = new List<int>();
            var equal = from n in arr
                where n == 5
                select n;
            foreach (var n in equal)
            {
                result.Add(n);
            }
            return result;
        }
    }
}
