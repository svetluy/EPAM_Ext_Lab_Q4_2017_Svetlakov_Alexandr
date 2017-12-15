namespace Task03
{
    using System;

    public class User
    {
        private const string StockValue = "Unknown";
        private readonly DateTime stockDate = DateTime.Today;

        public User()
        {
            this.InitUser(StockValue, StockValue, StockValue, this.stockDate);
        }

        public User(string name, string surName, string lastName, DateTime dateOfBirth)
        {
            this.InitUser(name, surName, lastName, dateOfBirth);
        }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string SurName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; private set; }

        public override string ToString()
        {
            return $"User:\n Name :{Name}, LastName:{LastName}, Surname: {SurName}, Date of Birth : {DateOfBirth.ToShortDateString()}, Age: {Age}";
        }

        private void InitUser(string name, string surName, string lastName, DateTime dateOfBirth)
        {
            this.Name = name;
            this.LastName = lastName;
            this.SurName = surName;
            this.DateOfBirth = dateOfBirth;
            float.TryParse((DateTime.Today - this.DateOfBirth).TotalDays.ToString(), out float daysDiff);
            this.Age = (int)(daysDiff / 365);
        }
    }
}
