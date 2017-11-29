#region Описание
// Написать программу, которая определяет площадь прямоугольника со
// сторонами a и b.Если пользователь вводит некорректные значения
// (отрицательные, или 0), должно выдаваться сообщение об ошибке.
// Возможность ввода пользователем строки вида «абвгд», или нецелых
// чисел игнорировать.
#endregion
namespace Task_01
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            int a, b;

            bool condition;
            do
            {
                try
                {
                    WriteLine("Enter a");
                    a = int.Parse(ReadLine());
                    WriteLine("Enter b");
                    b = int.Parse(ReadLine());

                    if (a <= 0 || b <= 0)
                    {
                        WriteLine("a and b must be more then 0.");
                        condition = true;
                    }
                    else
                    {
                        WriteLine($"S = {a}*{b} = {a * b}");

                        WriteLine("Would you like to continue?\n y    - Yes\n else - NO");
                        condition = ReadLine() == "y" ? true : false;
                    }
                }
                catch
                {
                    condition = true;
                }
            }
            while (condition);
        }
    }
}
