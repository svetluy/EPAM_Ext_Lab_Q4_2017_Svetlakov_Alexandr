namespace Task_02
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Enter number\nIs it positive?");
            WriteLine(ReadLine().IsPosNum());
            ReadKey();
        }
    }
}
