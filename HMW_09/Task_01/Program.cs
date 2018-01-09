namespace Task_01
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 3, 4, 5, 6, 7, 8, 9 };
            WriteLine("Source array :");
            foreach (var i in arr)
            {
                Write($"{i} ");
            }

            int sum = arr.Sum();
            WriteLine($"\nSum of elements is {sum}");
            ReadKey();
        }
    }
}
