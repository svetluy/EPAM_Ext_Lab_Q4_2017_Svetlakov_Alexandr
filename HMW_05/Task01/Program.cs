namespace Task01
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            System.ConsoleKeyInfo key = new System.ConsoleKeyInfo();
            do
            {
                int r = 0;

                WriteLine("Enter x");
                int.TryParse(ReadLine(), out int x);

                WriteLine("Enter y");
                int.TryParse(ReadLine(), out int y);

                do
                {
                    WriteLine("Enter radius,r>0");
                    int.TryParse(ReadLine(), out r);
                } while (r <= 0);

                Round r1 = new Round(x, y, r);
                WriteLine(r1);
                WriteLine($"Circumference of r1 is {r1.Сircumference():f3}, Square of r1 is {r1.Square():f3}");

                WriteLine("Would you like to continue?\ny - yes\nelse - no");
                key = ReadKey();
                WriteLine();
            } while (key.Key == System.ConsoleKey.Y);
        }
    }
}
