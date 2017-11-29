namespace Task02
{
    using static System.Math;

    public class Logic
    {
        public static double[] SquareRoot(double h, out double a, out double b, out double c, out double d)//todo pn не общее решение, а частное
        {
            double[] x = new double[2];
            a = Sqrt((Abs(Sin(8 * h)) + 17) / Pow(1 - (Sin(4 * h) * Cos((h * h) + 18)), 2));//todo pn метод не посчитает квадратное уравнение с другими параметрами
            b = 1 - Sqrt(3 / (3 + Abs(Tan(a * (h * h)) - Sin(a * h))));
            c = (a * (h * h) * Sin(b * h)) + (b * Pow(h, 3) * Cos(a * h));

            d = (b * b) - (4 * (a * c));

            if (d > 0)
            {
                x[0] = ((-1 * b) + Sqrt(d)) / 2 * a;
                x[1] = ((-1 * b) - Sqrt(d)) / 2 * a;
            }

            return x;
        }
    }
}
