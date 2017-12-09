using System.Globalization;

namespace Task03
{
    using System;

    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get;  }

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
            int.TryParse((DateTime.Now - DateOfBirth).TotalDays.ToString(CultureInfo.CurrentCulture), out int daysDiff);
            Age = daysDiff / 365;
        }
    }
}
