#region Описание
//Программа должна выводить пользователю промежуточные вычисления(например, a, b, c и дискриминант (если вычисляли при помощи него)
//и корни(если есть)).
#endregion

using static System.Console;
using static System.Math;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                WriteLine("Введи h");
                double.TryParse(ReadLine(), out double h);

                var x = SquareRoot(h, out double a, out double b, out double c, out double D);

                WriteLine($"a = {a:f5}, b = {b:f5}, c = {c:f5}, D = {D:f5}");
                if (D >= 0)
                    foreach (var x0 in x)
                        WriteLine($"x={x0}");
            }
        }

        private static double[] SquareRoot(double h, out double a,out double b,out double c,out double D)
        {
            double[] x = new double [2];
             a = Sqrt((Abs(Sin(8*h)) + 17) / Pow(1-Sin(4*h)*Cos(h*h + 18),2));
             b = 1 - Sqrt(3 / (3 + Abs((Tan(a * h * h)) - (Sin(a * h)))));
             c = a * h * h * Sin(b * h) + b * Pow(h, 3) * Cos(a * h);

             D = b * b - 4 * a * c;
            if (D > 0)
            {
                x[0] = (-1 * b + Sqrt(D)) / 2 * a;
                x[1] = (-1 * b - Sqrt(D)) / 2 * a;

            }
            else if (D == 0)
            {
                x[0] = (-1 * b + Sqrt(D)) / 2 * a;
            }
            else
            {
                WriteLine("Уравнение не имеет вещественных корней");
            }
            return x;
        }
    }
}
