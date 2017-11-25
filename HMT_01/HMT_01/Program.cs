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
            switch (choice)
            {
                case "а":
                    if (distanceToZero <= 1)
                        PositiveMessage(x, y, choice);
                    else
                        NegativeMessage(x, y, choice);
                    break;


                case "б":
                    if (distanceToZero <= 1 && (distanceToZero >= 0.5))
                        PositiveMessage(x, y, choice);
                    else
                        NegativeMessage(x, y, choice);
                    break;


                case "в":
                    if ((Abs(x) <= 1) && (Abs(y) <= 1))
                        PositiveMessage(x, y, choice);
                    else
                        NegativeMessage(x, y, choice);
                    break;


                case "г":
                    if ((Abs(x + y) <= 1) && (Abs(x - y) <= 1))
                        PositiveMessage(x, y, choice);
                    else
                        NegativeMessage(x, y, choice);
                    break;


                case "д":
                    if ((Abs(2 * x + y) <= 1) && (Abs(2 * x - y) <= 1))
                        PositiveMessage(x, y, choice);
                    else
                        NegativeMessage(x, y, choice);
                    break;


                case "е":
                    bool tmp1 = (x - 2 * y >= -2) && (x + 2 * y >= -2) && (x >= -2 && x <= 0);//удовлетворяет неравенствам на отрезке [-2,0]
                    bool tmp2 = distanceToZero <= 1 && (x <= 1 && x >= 0);
                    if (tmp1 || tmp2)//объединение множеств
                            PositiveMessage(x, y, choice);
                    else
                            NegativeMessage(x, y, choice);
                    break;


                case "ж":
                    if ((2 * x + y <= 1) && (2 * x - y >= 1) && (y >= -1))
                        PositiveMessage(x, y, choice);
                    else
                        NegativeMessage(x, y, choice);
                    break;


                case "з":
                    if ((Abs(x) <= 1) && (Abs(y) <= 2)&&(y<=Abs(x)))
                        PositiveMessage(x, y, choice);
                    else
                        NegativeMessage(x, y, choice);
                    break;


                case "и":
                    bool tmp3 = ((y <= 2 * x + 3) && (y >= (x - 1) / 3) && y < 0);//принадлежность первому треугольнику
                    bool tmp4 = ((y <= 2 * x + 3) && (y + x <= 0) && y >= 0);//принадлежность второму треугольнику 

                    if (tmp3 || tmp4)//принадлежность их объединению
                        PositiveMessage(x, y, choice);
                    else
                        NegativeMessage(x, y, choice);
                    break;


                case "к":
                    if (((y >= 1 && Abs(x) >= 1)) || (Abs(x) <= y))
                        PositiveMessage(x, y, choice);
                    else
                        NegativeMessage(x, y, choice);
                    break;


                default:
                    WriteLine("не верные данные");
                    break;
            }
        }

        private static void NegativeMessage(double x, double y, string choice) => WriteLine($"Точка ({x:f3};{y:f3}) не принадлежит фигуре {choice};");
        private static void PositiveMessage(double x, double y, string choice) => WriteLine($"Точка ({x:f3};{y:f3}) принадлежит фигуре {choice};");
    }
}
