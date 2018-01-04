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
            WriteLine($"{sender.Name} came");
            greetByUs?.Invoke(sender.Name);
            if (e.Date.Hour > 0 && e.Date.Hour < 13)
            {
                greetByUs += sender.MorningGreet;
            }
            else if (e.Date.Hour > 12 && e.Date.Hour < 17)
            {
                greetByUs += sender.AfternoonGreet;
            }
            else
            {
                greetByUs += sender.EveningGreet;
            }

            goodbye += sender.Goodbye;
        }

        public static void PersonLeft(Person sender, PersonEventArgs e)
        {
            WriteLine($"{sender.Name} left");
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
            WriteLine($"\'Goodbye, {personName}\', - {Name} said.");
        }

        private void MorningGreet(string personName)
        {
            WriteLine($"\'Good morning, {personName}\', - {Name} said.");
        }

        private void AfternoonGreet(string personName)
        {
            WriteLine($"\'Good aftrenoon, {personName}\', - {Name} said.");
        }

        private void EveningGreet(string personName)
        {
            WriteLine($"\'Good evening, {personName}\', - {Name} said.");
        }
    }
}
