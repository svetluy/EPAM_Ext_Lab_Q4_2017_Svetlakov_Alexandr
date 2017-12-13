namespace Task03
{
    using System;
    using System.Collections.Generic;
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>();
            ConsoleKeyInfo key;
            do
            {
                WriteLine("Create figure:\n1.Round\n2.Ring\n3.Rectangle\n4.Line\nElse - exit");
                key = ReadKey();
                WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.D0:

                        break;
                    case ConsoleKey.D1:
                        Round r1 = new Round
                        {
                            X = EnterData("Enter top left x coord, (1,1) is top left angle of workspace"), // квадрата, описанного вокруг круга
                            Y = EnterData("Enter top left y coord"),
                            Width = EnterData("Enter side of square")
                        };
                        figures.Add(r1);
                        WriteLine(r1);
                        break;
                    case ConsoleKey.D2:
                        Ring r2 = new Ring
                        {
                            X = EnterData("Enter top left x coord, (1,1) is top left angle of workspace"), // квадрата, описанного вокруг круга
                            Y = EnterData("Enter top left y coord"),
                            Width = EnterData("Enter side of square"),
                            InnerR = EnterData("Enter inner radius")
                        };
                        figures.Add(r2);
                        WriteLine(r2);
                        break;
                    case ConsoleKey.D3:
                        Rectangle r3 = new Rectangle
                        {
                            X = EnterData("Enter top left x coord, (1,1) is top left angle of workspace"), // квадрата, описанного вокруг круга
                            Y = EnterData("Enter top left y coord"),
                            Width = EnterData("Enter width"),
                            Height = EnterData("Enter height")
                        };
                        figures.Add(r3);
                        WriteLine(r3);
                        break;
                    case ConsoleKey.D4:
                        Line line = new Line()
                        {
                            X = EnterData("Enter top left x coord, (1,1) is top left angle of workspace"), // квадрата, описанного вокруг круга
                            Y = EnterData("Enter top left y coord"),
                            Width = EnterData("Enter width"),
                            Height = EnterData("Enter height")
                        };
                        figures.Add(line);
                        WriteLine(line);
                        break;
                    default:
                        break;
                }

                WriteLine();
                WriteLine($"Figures total {figures.Count}");
                foreach (var figure in figures)
                {
                    WriteLine($"Figure: {figure.Name}\n{figure}");
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
