namespace Task_02
{
    using System;

    public class PersonEventArgs : EventArgs
    {
        public PersonEventArgs(DateTime date)
        {
            this.Date = date;
        }

        public DateTime Date { get; }
    }
}