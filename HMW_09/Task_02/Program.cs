namespace Task_02
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            string number = "1256";
            WriteLine(number.IsPosNum());
            number = "-322";
            WriteLine(number.IsPosNum());
            ReadKey();
        }
    }
}
