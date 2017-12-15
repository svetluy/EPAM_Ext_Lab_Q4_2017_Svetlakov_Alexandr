// На основе класса User(см.задание 3 из предыдущей темы), создать
// класс Employee, описывающий сотрудника фирмы.В дополнение к
// полям пользователя добавить поля «стаж работы» и «должность».
// Обеспечить нахождение класса в заведомо корректном состоянии.

namespace Task01
{
    using System;
    using System.Collections.Generic;
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<User> userList = new List<User>();

            ConsoleKeyInfo key;
            do
            {
                WriteLine("Create:\n1.User\n2.EMployee\nElse - exit");
                key = ReadKey();
                WriteLine();

                string name;
                string lastName;
                string surName;
                DateTime dateOfBirth;

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        name = Enterdata("Enter name");
                        lastName = Enterdata("Enter lastname");
                        surName = Enterdata("Enter surname");
                        DateTime.TryParse(Enterdata("Enter date of birth"), out dateOfBirth);
                        User user1 = new User(name, surName, lastName, dateOfBirth);
                        userList.Add(user1);
                        break;
                    case ConsoleKey.D2:
                        name = Enterdata("Enter name");
                        lastName = Enterdata("Enter lastname");
                        surName = Enterdata("Enter surname");
                        DateTime.TryParse(Enterdata("Enter date of birth"), out dateOfBirth);
                        int.TryParse(Enterdata("Enter work experience in months"), out int workExp1);
                        TimeSpan workExp = new TimeSpan(workExp1 * 30, 0, 0, 0);
                        var seniority = Enterdata("Enter seniority");
                        Employee emp = new Employee(name, surName, lastName, dateOfBirth, workExp, seniority);
                        userList.Add(emp);
                        break;
                    default:
                        break;
                }

                WriteLine($"Total number of users {userList.Count}");
                foreach (var user in userList)
                {
                    WriteLine($"\n{user}");
                }

                WriteLine("Create new user?\ny - yes\nelse - no");
                key = ReadKey();
                WriteLine();
            }
            while (key.Key == ConsoleKey.Y);
        }

        private static string Enterdata(string message)
        {
            WriteLine(message);
            return ReadLine();
        }
    }
}
