#region Описание
// Задание 2
// Дано действительное число h. Выяснить, имеет ли уравнение ax^2 + bx + c = 0 дествительные корни, при заданных a, b, c, зависящих от h.
// Если действительные корни существуют, то найти их. В противном случае ответом должно служить сообщение, что действительных корней нет.
// Программа должна выводить пользователю промежуточные вычисления (например, a, b, c и дискриминант (если вычисляли при помощи него) и корни (если есть)).
#endregion
namespace Task02
{
    using static System.Console;
    using static System.Math;

    public class Program
    {
        public static void Main(string[] args)
        {
            bool cont = true;
            while (cont)
            {
                WriteLine("Enter h");
                double.TryParse(ReadLine(), out double h);

                var x = SquareRoot(h, out double a, out double b, out double c, out double d);

                WriteLine($"a = {a:f5}, b = {b:f5}, c = {c:f5}, D = {d:f5}");

                if (d > 0)
                {
                    foreach (var x0 in x)
                    {
                        WriteLine($"x={x0:f5}");
                    }
                }
                else if (d == 0)
                {
                    WriteLine($"x={x[0]:f5}");
                }
                else
                {
                    WriteLine("There is no real roots");
                }

                while (cont)
                {
                    WriteLine("would like to continue?\n y - Yes \n n - No ");
                    string choice = ReadLine();
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

        private static double[] SquareRoot(double h, out double a, out double b, out double c, out double d)
        {
            double[] x = new double[2];
             a = Sqrt((Abs(Sin(8 * h)) + 17) / Pow(1 - (Sin(4 * h) * Cos((h * h) + 18)), 2));
             b = 1 - Sqrt(3 / (3 + Abs(Tan(a * (h * h)) - Sin(a * h))));
             c = (a * (h * h) * Sin(b * h)) + (b * Pow(h, 3) * Cos(a * h));

             d = (b * b) - (4 * (a * c));

             x[0] = ((-1 * b) + Sqrt(d)) / 2 * a;
             x[1] = ((-1 * b) - Sqrt(d)) / 2 * a;

            return x;
        }
    }
}
