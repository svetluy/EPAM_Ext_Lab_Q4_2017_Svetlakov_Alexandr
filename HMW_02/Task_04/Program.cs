#region Описание
// Написать программу, которая запрашивает с клавиатуры число N и
// выводит на экран «изображение», состоящее из N треугольников.
#endregion

namespace Task_04
{
    using System;
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            ConsoleKeyInfo key;

            do
            {
                int n;
                do
                {
                    WriteLine("Enter N");
                    int.TryParse(ReadLine(), out n);
                }
                while (n <= 0);

                WriteTriangle(n, EnterString("Enter delimeter"), EnterString("Enter symbol"));

                WriteLine("Would you like to continue?\n y    - Yes\n else - No\n");
                key = ReadKey();
                WriteLine();
            }
            while (key.Key == ConsoleKey.Y);
        }

        private static string EnterString(string message)
        {
            WriteLine(message);
            return ReadLine();
        }

        private static void WriteTriangle(int n, string delimeter, string symbol)
        {
            int j, k;
            for (int i = 0; i <= n; i++)
            {
                for (k = 0; k < i; k++)
                {
                    for (j = 0; j < (n - k); j++)
                    {
                        Write(delimeter);
                    }

                    for (j = 0; j <= 2 * k; j++)
                    {
                        Write(symbol);
                    }

                    WriteLine();
                }
            }
        }
    }
}
