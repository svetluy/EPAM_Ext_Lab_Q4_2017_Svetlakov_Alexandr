// Написать программу, которая определяет сумму неотрицательных
// элементов в одномерном массиве.Число элементов в массиве и их тип
// определяются разработчиком.

namespace Task03
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

                WriteLine("Array");
                WriteArr(arr);

                WriteLine($"Sum positive values in array is {SumPositive(arr)}\n");

                WriteLine("Would you like to continue?\n y - Yes\n else - No");

                key = ReadKey();

                WriteLine();
            }
            while (key.Key == System.ConsoleKey.Y);
        }
    }
}
