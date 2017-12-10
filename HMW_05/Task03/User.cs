namespace Task03
{
    using System;

    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; private set; }

        public User()
        {
            Name = "Unknown";
            LastName = "Unknown";
            SurName = "Unknown";
            DateOfBirth = DateTime.Now;
            Age = 0;
        }

        public User(string name,string surName,string lastName,DateTime dateOfBirth)
        {
            Name = name;
            LastName = lastName;
            SurName = surName;
            DateOfBirth = dateOfBirth;
            float.TryParse(((DateTime.Now - DateOfBirth).TotalDays.ToString()), out float daysDiff);
            Age = (int)(daysDiff / 365);
        }

        public override string ToString()
        {
            return $"User:\n Name :{Name}, LastName:{LastName}, Surname: {SurName}, Date of Birth : {DateOfBirth.ToShortDateString()}, Age: {Age}";
        }
    }
}
