// Написать программу, которая генерирует случайным образом
// элементы массива(число элементов в массиве и их тип определяются
// разработчиком), определяет для него максимальное и минимальное
// значения, сортирует массив и выводит полученный результат на экран.

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

                WriteLine("Array");
                WriteArr(arr);

                SortArr(arr);

                WriteLine("Sorted array");
                WriteArr(arr);

                WriteLine($"Max value in arr is {arr[arr.Length - 1]}\nMin value in arr is {arr[0]}");

                WriteLine("Would you like to continue?\n y - Yes\n else - No");

                key = ReadKey();

                WriteLine();
            }
            while (key.Key == System.ConsoleKey.Y);
        } 
    }
}
