namespace Task_01
{
    using System;
    using static Comparison;

    public class Program
    {
        public static void Main(string[] args)
        {
            var сomparisonDel = new Сomparison(СomparisonMethod);
            string[] strings = { "qwe", "qwert", "abc", "qwerty" };
            Sort(strings, сomparisonDel, 0, strings.Length - 1);
            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }

            Console.ReadKey();
        }
    }
}
