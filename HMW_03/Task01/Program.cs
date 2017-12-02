namespace Task01
{
    using static System.Console;
    using static Logic;

    internal class Program
    {
        public static void Main(string[] args)
        {
            System.ConsoleKeyInfo key;
            do
            {
                var arr = CreateArr(InputData("Input array length, n > 0 "), InputData("Input max possible value in array, value > 0 "));

                WriteArr(arr);

                SortArr(arr);

                WriteArr(arr);

                WriteLine($"Max Value in Arr is {arr[arr.Length - 1]}\nMin Value in Arr is {arr[0]}");

                WriteLine("Would you like to continue?\n y - Yes\n else - No");

                key = ReadKey();

                WriteLine();
            }
            while (key.Key == System.ConsoleKey.Y);
        } 
    }
}
