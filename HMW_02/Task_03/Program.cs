#region Описание
// Написать программу, которая запрашивает с клавиатуры число N и
// выводит на экран «изображение», состоящее из N строк.
#endregion
namespace Task_03
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            ForegroundColor = System.ConsoleColor.DarkCyan;

            int n;
            bool condition = true;
            while (condition)
            {
                int i, j;

                do
                {
                    WriteLine("Enter N");
                    int.TryParse(ReadLine(), out n);
                }
                while (n <= 0);

                for (i = 0; i < n; i++)
                {
                    for (j = 0; j <= (n - i); j++)
                    {
                        Write(" ");
                    }
                    for (j = 0; j < 2*i+1; j++)
                    {
                        Write("*");
                    }
                    WriteLine();
                }

                WriteLine("Would you like to continue?\n y    - Yes\n else - NO");
                condition = ReadLine() == "y" ? true : false;
            }
        }
    }
}
