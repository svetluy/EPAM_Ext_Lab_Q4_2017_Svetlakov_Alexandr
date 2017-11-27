#region Описание
//Написать консольное приложение, которое проверяет принадлежность точки заштрихованной области.
//Пользователь вводит координаты точки (x; y) и выбирает букву графика(a-к). В консоли должно высветиться сообщение: «Точка[(x; y)] принадлежит фигуре[г]».
#endregion

using static System.Console;
using static System.Math;

namespace HMT_01
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                WriteLine("Введи х");
                double.TryParse(ReadLine(), out double x);

                WriteLine("Введи y");
                double.TryParse(ReadLine(), out double y);

                WriteLine("Выбери фигуру");
                string choice = ReadLine();

                Belongs(x, y, choice);
            }
        }

        private static void Belongs(double x, double y, string choice)
        {
            double distanceToZero = Sqrt(x * x + y * y);
            bool answer = false;
            switch (choice)
            {
                case "а":
                    answer = distanceToZero <= 1;
                    Answer(x, y, choice, answer);
                    break;


                case "б":
                    answer = distanceToZero <= 1 && (distanceToZero >= 0.5);
                    Answer(x, y, choice, answer);
                    break;


                case "в":
                    answer = (Abs(x) <= 1) && (Abs(y) <= 1);
                    Answer(x, y, choice, answer);
                    break;


                case "г":
                    answer = (Abs(x + y) <= 1) && (Abs(x - y) <= 1);
                    Answer(x, y, choice, answer);
                    break;


                case "д":
                    answer = (Abs(2 * x + y) <= 1) && (Abs(2 * x - y) <= 1);
                    Answer(x, y, choice, answer);
                    break;


                case "е":
                    bool tmp1 = (x - 2 * y >= -2) && (x + 2 * y >= -2) && (x >= -2 && x <= 0);//удовлетворяет неравенствам на отрезке [-2,0]
                    bool tmp2 = distanceToZero <= 1 && (x <= 1 && x >= 0);
                    answer = tmp1 || tmp2;//объединение множеств
                    Answer(x, y, choice, answer);
                    break;


                case "ж":
                    answer = (2 * x + y <= 1) && (2 * x - y >= 1) && (y >= -1);
                    Answer(x, y, choice, answer);
                    break;


                case "з":
                    answer = (Abs(x) <= 1) && (Abs(y) <= 2) && (y <= Abs(x));
                    Answer(x, y, choice, answer);
                    break;


                case "и":
                    bool tmp3 = ((y <= 2 * x + 3) && (y >= (x - 1) / 3) && y < 0);//принадлежность первому треугольнику
                    bool tmp4 = ((y <= 2 * x + 3) && (y + x <= 0) && y >= 0);//принадлежность второму треугольнику 
                    answer = tmp3 || tmp4;//принадлежность их объединению
                    Answer(x, y, choice, answer);
                    break;


                case "к":
                    answer = ((y >= 1 && Abs(x) >= 1)) || (Abs(x) <= y);
                    Answer(x, y, choice, answer);
                    break;


                default:
                    WriteLine("не верные данные");
                    break;
            }
        }

        private static void Answer(double x, double y, string choice, bool tmp)
        {
            if (tmp)
                PositiveMessage(x, y, choice);
            else
                NegativeMessage(x, y, choice);
        }

        private static void NegativeMessage(double x, double y, string choice) => WriteLine($"Точка ({x:f3};{y:f3}) не принадлежит фигуре {choice};");
        private static void PositiveMessage(double x, double y, string choice) => WriteLine($"Точка ({x:f3};{y:f3}) принадлежит фигуре {choice};");
    }
}
