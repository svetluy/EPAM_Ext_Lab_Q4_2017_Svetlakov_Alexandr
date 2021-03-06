﻿// Написать программу, которая заменяет все положительные элементы
// в трёхмерном массиве на нули.Число элементов в массиве и их тип
// определяются разработчиком.

namespace Task02
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

                WriteLine("Now replace positive\n");

                ReplacePositive(arr);

                WriteArr(arr);

                WriteLine("Would you like to continue?\n y - Yes\n else - No");

                key = ReadKey();

                WriteLine();
            }
            while (key.Key == System.ConsoleKey.Y);
        }
    }
}
