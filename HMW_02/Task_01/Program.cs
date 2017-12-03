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

    public class Program//todo pn решение частной задачи
    {
        public static void Main(string[] args)
        {
            int a, b;
            bool condition;

            do
            {
                a = EnterData("Enter a");
                b = EnterData("Enter b");

                WriteLine($"S = {a}*{b} = {a * b}");

                WriteLine("Would you like to continue?\n y    - Yes\n else - No");
                condition = ReadLine() == "y" ? true : false;
            }
            while (condition);
        }

        private static int EnterData(string message)
        {
            int a;
            do
            {
                WriteLine(message);
                WriteLine("a and b must be more then 0.");
                a = int.Parse(ReadLine());
            }
            while (a <= 0);
            return a;
        }
    }
}
