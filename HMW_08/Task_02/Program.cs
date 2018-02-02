namespace Task_02
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            var john = new Person { Name = "John" };
            var bill = new Person { Name = "Bill" };
            var hugo = new Person { Name = "Hugo" };

            john.OnCame();
            bill.OnCame();
            hugo.OnCame();

            john.OnLeft();
            bill.OnLeft();
            hugo.OnLeft();

            ReadKey();
        }
    }
}
