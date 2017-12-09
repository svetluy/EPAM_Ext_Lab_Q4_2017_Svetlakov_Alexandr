namespace Task01
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            Round r1 = new Round(5,6,4);
            WriteLine(r1);
            WriteLine($"Circumference of r1 is {r1.Сircumference():f3}, Square of r1 is {r1.Square():f3}");
            r1.R = -5;
            WriteLine(r1);
            Round r2 = new Round(1, 2, -7);
            WriteLine(r2);
            ReadKey();
        }
    }
}
