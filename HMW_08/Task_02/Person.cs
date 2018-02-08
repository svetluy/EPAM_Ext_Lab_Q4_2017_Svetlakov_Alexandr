namespace Task_02
{
    using System;
    using static System.Console;

    public class Person
    {
        private const string CameMes = "{0} came.",
            LeftMes = "{0} left.",
            GoodbyeMes = "\'Goodbye, {0}\', - {1} said",
            MorningGreet = "\'Good morning, {0}\', - {1} said.",
            AfternoonGreet = "\'Good afternoon, {0}\', - {1} said.",
            EveningGreet = "\'Good evening, {0}\', - {1} said.";

        private static Message greetByUs;
        private static Message goodbye;

        public delegate void Message(string name);

        public delegate void EventHandler<in T>(Person sender, T e);

        public event EventHandler<PersonEventArgs> Came; 

        public event EventHandler<PersonEventArgs> Left;

        public string Name { get; set; }

        public static void PersonCame(Person sender, PersonEventArgs e)
        {
            WriteLine(CameMes, sender.Name); // todo pn хардкод. ну и помнишь про IConsole? было бы здорово реализовать таким образом.
            greetByUs?.Invoke(sender.Name);
            greetByUs += sender.Greet;

            goodbye += sender.Goodbye;
        }

        public static void PersonLeft(Person sender, PersonEventArgs e)
        {
            WriteLine(LeftMes, sender.Name); // todo pn хардкод
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
            WriteLine(GoodbyeMes, personName, this.Name); // todo pn хардкод
        }

        private void Greet(string personName)
        {
            if (DateTime.Now.Hour > 0 && DateTime.Now.Hour < 13)
            {
                WriteLine(MorningGreet, personName, this.Name);
            }
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 17)
            {
                WriteLine(AfternoonGreet, personName, this.Name);
            }
            else
            {
                WriteLine(EveningGreet, personName, this.Name);
            }
        }
    }
}
