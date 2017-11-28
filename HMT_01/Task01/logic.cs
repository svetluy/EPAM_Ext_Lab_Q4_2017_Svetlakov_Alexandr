namespace HMT_01
{
    using static System.Math;
    using static System.Console;

    public static class Logic
    {
        public static void Belongs(double x, double y, string choice)
        {
            double distanceToZero = Sqrt((x * x) + (y * y));
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
                    answer = (Abs((2 * x) + y) <= 1) && (Abs((2 * x) - y) <= 1);
                    Answer(x, y, choice, answer);
                    break;

                case "е":
                    bool tmp1 = (x - (2 * y) >= -2) && (x + (2 * y) >= -2) && (x >= -2 && x <= 0); // удовлетворяет неравенствам на отрезке [-2,0]
                    bool tmp2 = distanceToZero <= 1 && (x <= 1 && x >= 0);
                    answer = tmp1 || tmp2; // объединение множеств
                    Answer(x, y, choice, answer);
                    break;

                case "ж":
                    answer = ((2 * x) + y <= 1) && ((2 * x) - y >= 1) && (y >= -1);
                    Answer(x, y, choice, answer);
                    break;

                case "з":
                    answer = (Abs(x) <= 1) && (Abs(y) <= 2) && (y <= Abs(x));
                    Answer(x, y, choice, answer);
                    break;

                case "и":
                    bool tmp3 = (y <= (2 * x) + 3) && (y >= (x - 1) / 3) && y < 0; // принадлежность первому треугольнику
                    bool tmp4 = (y <= (2 * x) + 3) && (y + x <= 0) && y >= 0; // принадлежность второму треугольнику 
                    answer = tmp3 || tmp4; // принадлежность их объединению
                    Answer(x, y, choice, answer);
                    break;

                case "к":
                    answer = (y >= 1 && Abs(x) >= 1) || (Abs(x) <= y);
                    Answer(x, y, choice, answer);
                    break;

                default:
                    WriteLine("Wrong input");
                    break;
            }
        }

        private static void Answer(double x, double y, string choice, bool tmp) => WriteLine($"Точка ({x:f3};{y:f3}) {Not(tmp)} принадлежит фигуре {choice};");

        private static string Not(bool tmp) => tmp ? string.Empty : "не";
    }
}
