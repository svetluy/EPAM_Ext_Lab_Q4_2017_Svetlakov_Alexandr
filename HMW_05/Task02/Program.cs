namespace Task02
{
    using static System.Console;
    public class Program
    {
        public static void Main(string[] args)
        {
            System.ConsoleKeyInfo key = new System.ConsoleKeyInfo();
            do
            {
                WriteLine("Enter triangle sides");
                int a = EnterSides("Enter a, a>0");
                int b = EnterSides("Enter b, b>0");
                int c = EnterSides("Enter c, c>0");

                Triangle t1 = new Triangle(a, b, c);
                WriteLine(t1);
                WriteLine($"Perimeter = {t1.Perimeter}, Square = {t1.Square:f3}");

                WriteLine("Would you like to continue?\ny - yes\nelse - no");
                key = ReadKey();
                WriteLine();
            }
            while (key.Key == System.ConsoleKey.Y);
        }

        private static int EnterSides(string message)
        {
            int x;
            do
            {
                WriteLine(message);
                int.TryParse(ReadLine(), out x);
            }
            while (x <= 0);
            return x;
        }
    }
}
