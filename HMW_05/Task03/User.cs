namespace Task03
{
    using System;

    public class User
    {
        public User()
        {
            this.Name = "Unknown";
            this.LastName = "Unknown";
            this.SurName = "Unknown";
            this.DateOfBirth = DateTime.Now;
            this.Age = 0;
        }

        public User(string name, string surName, string lastName, DateTime dateOfBirth)
        {
            this.Name = name;
            this.LastName = lastName;
            this.SurName = surName;
            this.DateOfBirth = dateOfBirth;
            float.TryParse((DateTime.Now - this.DateOfBirth).TotalDays.ToString(), out float daysDiff);
            this.Age = (int)(daysDiff / 365);
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
    }
}
