#region Описание
// Написать программу, которая запрашивает с клавиатуры число N и
// выводит на экран «изображение», состоящее из N строк.
#endregion
namespace Task_02
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            ForegroundColor = System.ConsoleColor.DarkCyan;

            int n;
            bool condition;
            do
            {
                do
                {
                    WriteLine("Enter N");
                    int.TryParse(ReadLine(), out n);
                }
                while (n <= 0);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        Write("*");
                    }

                    WriteLine();
                }

                WriteLine("Would you like to continue?\n y    - Yes\n else - NO");
                condition = ReadLine() == "y" ? true : false;
            }
            while (condition);
        }
    }
}
