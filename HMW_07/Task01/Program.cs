namespace Task01
{
    using System;
    using static System.Console;

    class Program
    {
        static void Main(string[] args) // 
        {
            ConsoleKeyInfo key;
            do
            {
                WriteLine("Enter number of persons");
                int.TryParse(ReadLine(), out int n);

                PersonCircle personCircle = new PersonCircle(n);
                int surviverNumber = personCircle.RemovePersons(); 
                WriteLine($"Surviver person number is {surviverNumber}");
                WriteLine("Would you like to continue?");
                key = ReadKey();
            }
            while (key.Key == ConsoleKey.Y);
        }
    }
}
