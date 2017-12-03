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
            do
            {
                do
                {
                    WriteLine("Enter N");
                    int.TryParse(ReadLine(), out n);
                }
                while (n <= 0);

                WriteLine("Enter symbol");
                WriteTriangle(n,ReadLine());

                WriteLine("Would you like to continue?\n y    - Yes\n else - NO");
            }
            while (ReadLine() == "y");
        }

        private static void WriteTriangle(int n,string s)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Write(s);//todo pn хардкод
                }

                WriteLine();
            }
        }
    }
}
