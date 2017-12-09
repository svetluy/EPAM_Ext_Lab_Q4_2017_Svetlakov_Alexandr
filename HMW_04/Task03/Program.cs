namespace Task03
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
                WriteLine("Enter step");
                int.TryParse(ReadLine(), out int step);

                WriteLine("Enter number of steps");
                int.TryParse(ReadLine(), out int n);

                for (int i = 1; i <= n; i++)
                {
                    WriteLine($"Number of iterations {step * i},  without stringbuilder {ElapsedTime(step * i)}ms, with stringbuilder {ElapsedTimeSb(step * i)}ms");
                }

                WriteLine("Would you like to continue?\n y - Yes\n else - No");

                key = ReadKey();

                WriteLine();
            }
            while (key.Key == System.ConsoleKey.Y);
        }
    }
}
