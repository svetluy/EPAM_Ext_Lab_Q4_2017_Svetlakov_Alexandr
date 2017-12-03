namespace Task02
{
    using static System.Math;

    public class Logic
    {
        public static double[] SquareRoot(double a, double b, double c,out double d)//todo pn не общее решение, а частное
        {
            double[] x = new double[2];

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
