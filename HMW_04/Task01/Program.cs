namespace Task01
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
                WriteLine("Enter string");
                string input = ReadLine();

                WriteLine($"Average word's length in line is {AvLength(input)}");

                WriteLine("Would you like to continue?\n y - Yes\n else - No");

                key = ReadKey();

                WriteLine();
            }
            while (key.Key == System.ConsoleKey.Y);
        }
    }
}
