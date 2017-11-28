#region Описание
// Задание 1
// Написать консольное приложение, которое проверяет принадлежность точки заштрихованной области.
// Пользователь вводит координаты точки (x; y) и выбирает букву графика(a-к).
// В консоли должно высветиться сообщение: «Точка[(x; y)] принадлежит фигуре[г]».
#endregion
namespace HMT_01
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            bool cont = true;
            while (cont)
            {
                WriteLine("Enter х");
                double.TryParse(ReadLine(), out double x);

                WriteLine("Enter y");
                double.TryParse(ReadLine(), out double y);

                WriteLine("Choose figure");
                string choice = ReadLine();

                Logic.Belongs(x, y, choice);

                while (cont)
                {
                    WriteLine("would like to continue?\n y - Yes \n n - No ");
                    choice = ReadLine();
                    if (choice == "y")
                    {
                        break;
                    }
                    else if (choice == "n")
                    {
                        cont = false;
                    }
                    else
                    {
                        cont = true;
                    }
                }
            }
        }
    }
}
