namespace Task_01
{
    public delegate bool Сomparison(string s1, string s2);

    public class Comparison
    {
        public static bool СomparisonMethod(string s1, string s2)
        {
            if (s1.Length > s2.Length)
            {
                return true;
            }
            else
            {
                if (string.Compare(s1, s2) > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public static void Sort(string[] strings, Сomparison del)//todo pn давай уже не пузырьком сортировать?
        {
            for (int i = 0; i < strings.Length - 1; i++)
            {
                for (int j = i + 1; j < strings.Length; j++)
                {
                    if (del(strings[i], strings[j]))
                    {
                        var temp = strings[i];
                        strings[i] = strings[j];
                        strings[j] = temp;
                    }
                }
            }
        }
    }
}