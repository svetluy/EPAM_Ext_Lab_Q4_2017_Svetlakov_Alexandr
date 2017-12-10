namespace Task03
{
    using System;
    using static System.Console;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            List <User> userList = new List<User>();

            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                while (key.Key == System.ConsoleKey.Y) ;
                WriteLine("Create new user");
                string name = Enterdata("Enter name");
                string lastName = Enterdata("Enter lastname");
                string surName = Enterdata("Enter surname");
                DateTime.TryParse(Enterdata("Enter date of birth"), out DateTime dateOfBirth);
                User user1 = new User(name, surName, lastName, dateOfBirth);
                userList.Add(user1);
                WriteLine($"Total number of users {userList.Count}");
                foreach (var user in userList)
                {
                    WriteLine($"\n{user}");
                }

                WriteLine("Create new user?\ny - yes\nelse - no");
                key = ReadKey();
                WriteLine();
            } while (key.Key == ConsoleKey.Y);
        }

        private static string Enterdata(string message)
        {
            WriteLine(message);
            return ReadLine();
        }
    }
}
