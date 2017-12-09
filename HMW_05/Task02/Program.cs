namespace Task02
{
    using static System.Console;
    public class Program
    {
        public static void Main(string[] args)
        {
            Triangle t1 = new Triangle(3,4,5);
            WriteLine(t1);
            WriteLine($"Perimeter = {t1.Perimeter}, Square = {t1.Square}");
            Triangle t2 = new Triangle(2, -2, 1); // т.к такого треугольника не существует, его поля заполняются знач по умолчанию для теугольника
            WriteLine(t2);
            ReadKey();
        }
    }
}
