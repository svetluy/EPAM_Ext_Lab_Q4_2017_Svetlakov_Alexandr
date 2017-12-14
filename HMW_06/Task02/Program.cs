// Создать класс Ring(кольцо), описываемое координатами центра,
// внешним и внутренним радиусами, а также свойствами, позволяющими
// узнать площадь кольца и суммарную длину внешней и внутренней
// границ кольца.Обеспечить нахождение класса в заведомо корректном
// состоянии.

namespace Task02
{
    using System;
    using System.Collections.Generic;
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Round> figures = new List<Round>();
            ConsoleKeyInfo key;
            do
            {
                WriteLine("Create figure:\n1.Round\n2.Ring\nElse - exit");
                key = ReadKey();
                WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.D0:

                        break;
                    case ConsoleKey.D1:
                        Round r1 = new Round
                        {
                            X = EnterData("Enter x"), 
                            Y = EnterData("Enter y"),
                            R = EnterData("Enter radius")
                        };
                        figures.Add(r1);
                        WriteLine(r1);
                        break;
                    case ConsoleKey.D2:
                        Ring r2 = new Ring
                        {
                            X = EnterData("Enter x"),
                            Y = EnterData("Enter y"),
                            R = EnterData("Enter radius"),
                            InnerR = EnterData("Enter inner radius")
                        };
                        figures.Add(r2);
                        WriteLine(r2);
                        break;
                    default:
                        break;
                }

                WriteLine();
                WriteLine($"Figures total {figures.Count}");
                foreach (var figure in figures)
                {
                    WriteLine($"Figure: {figure}");
                }

                WriteLine("\nWould you like to create new figure?\nY - yes, else - no");
                key = ReadKey();
            }
            while (key.Key == ConsoleKey.Y);
        }

        private static int EnterData(string message)
        {
            WriteLine(message);
            int.TryParse(ReadLine(), out int x);
            return x;
        }
    }
}
