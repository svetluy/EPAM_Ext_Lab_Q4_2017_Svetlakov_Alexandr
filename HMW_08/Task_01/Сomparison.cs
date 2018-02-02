namespace Task_01
{
    public delegate bool Сomparison(string s1, string s2);

    public class Comparison
    {
        public static bool СomparisonMethod(string s1, string s2)
        {
            if (s1.Length < s2.Length)
            {
                return true;
            }
            else
            {
                if (string.Compare(s1, s2) < 0)
                {
                    return true;
                }

                return false;
            }
        }

        public static void Sort(string[] strings, Сomparison del, int first, int last) // заменил на быструю сортировку
        {
            int f = first, l = last;
            var mid = strings[(f + l) / 2];
            do
            {
                while (del(strings[f], mid))
                {
                    f++;
                }

                while (del(mid, strings[l]))
                {
                    l--;
                }

                if (f <= l)
                {
                    var count = strings[f];
                    strings[f] = strings[l];
                    strings[l] = count;
                    f++;
                    l--;
                }
            }
            while (f < l);
            if (first < l)
            {
                Sort(strings, del, first, l);
            }

            if (f < last)
            {
                Sort(strings, del, f, last);
            }
        }
    }
}