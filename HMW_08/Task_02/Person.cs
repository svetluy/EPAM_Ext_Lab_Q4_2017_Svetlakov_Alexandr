namespace Task_02
{
    using System;
    using static System.Console;

    public class Person
    {
        private static Message greetByUs;
        private static Message goodbye;

        public delegate void Message(string name);

        public delegate void EventHandler<in T>(Person sender, T e);

        public event EventHandler<PersonEventArgs> Came; 

        public event EventHandler<PersonEventArgs> Left;

        public string Name { get; set; }

        public static void PersonCame(Person sender, PersonEventArgs e)
        {
            WriteLine($"{sender.Name} came"); // todo pn хардкод. ну и помнишь про IConsole? было бы здорово реализовать таким образом.
            greetByUs?.Invoke(sender.Name);
            greetByUs += sender.Greet;

            goodbye += sender.Goodbye;
        }

        public static void PersonLeft(Person sender, PersonEventArgs e)
        {
            WriteLine($"{sender.Name} left"); // todo pn хардкод
            if (goodbye != null)
            {
                goodbye -= sender.Goodbye;
                goodbye?.Invoke(sender.Name);
            }
        }

        public void OnCame()
        {
            this.Came += PersonCame;
            this.Came?.Invoke(this, new PersonEventArgs(DateTime.Now));
        }

        public void OnLeft()
        {
            this.Left += PersonLeft;
            this.Left?.Invoke(this, new PersonEventArgs(DateTime.Now));
        }

        private void Goodbye(string personName)
        {
            WriteLine($"\'Goodbye, {personName}\', - {Name} said."); // todo pn хардкод
        }

        private void Greet(string personName)
        {
            if (DateTime.Now.Hour > 0 && DateTime.Now.Hour < 13)
            {
                WriteLine($"\'Good morning, {personName}\', - {Name} said.");
            }
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 17)
            {
                WriteLine($"\'Good aftrenoon, {personName}\', - {Name} said.");
            }
            else
            {
                WriteLine($"\'Good evening, {personName}\', - {Name} said.");
            }
		}
    }
}
