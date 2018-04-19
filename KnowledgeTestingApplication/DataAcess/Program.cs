using System;

namespace DataAcess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            var test = TestManagment.GetTestsForPage(2,2);
            Console.ReadKey();
        }
    }
}
