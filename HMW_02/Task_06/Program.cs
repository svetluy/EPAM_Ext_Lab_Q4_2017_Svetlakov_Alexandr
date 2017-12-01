namespace Task_06
{
    using System;
    using System.Collections.Generic;
    using static System.Console;
    using static Task_06.Logic;

    public class Program
    {
        public static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            ConsoleKeyInfo key;

            int boldKeyCounter = 0, italicKeyCounter = 0, underlineKeyCounter = 0;
            List<string> param = new List<string>();

            do
            {
                CheckParams("None", param, param.Count == 0);

                Write("Параметры надписи : ");
                foreach (var p in param)
                {
                    Write($"{p} ");
                }

                WriteLine();

                WriteLine("Введите:\n\t1: bold\n\t2: italic\n\t3: underline");
                key = ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    boldKeyCounter++;
                    IsInList(boldKeyCounter, "Bold", param);
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    italicKeyCounter++;
                    IsInList(italicKeyCounter, "Italic", param);
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    underlineKeyCounter++;
                    IsInList(underlineKeyCounter, "Underline", param);
                }
                else
                {
                    WriteLine("\n Неизвестный параметр");
                }

                WriteLine();
            }
            while (true);
        }
    }
}
