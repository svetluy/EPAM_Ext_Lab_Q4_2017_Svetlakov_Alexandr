namespace Task02
{
    using static System.Console;
    using static Logic;

    public class Program
    {
        public static void Main(string[] args)
        {
            System.ConsoleKeyInfo key;

            do
            {
                WriteLine($"Result: {Double(Input("Enter first string"), Input("Enter second string"))}");

                WriteLine("Would you like to continue?\n y - Yes\n else - No");

                key = ReadKey();

                WriteLine();
            }
            while (key.Key == System.ConsoleKey.Y);
        }
    }
}
