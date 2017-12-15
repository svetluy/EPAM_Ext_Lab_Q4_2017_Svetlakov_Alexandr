namespace Task01
{
    using System;

    public class Employee : User
    {
        public Employee()
        {
        }

        public Employee(string name, string surName, string lastName, DateTime dateOfBirth, TimeSpan workExp, string seniority) : base(name, surName, lastName, dateOfBirth)
        {
            this.Seniority = seniority;
            this.WorkExp = workExp;
        }

        public TimeSpan WorkExp { get; private set; }

        public string Seniority { get; private set; }

        public override string ToString()
        {
             return $"Employee:\n Name :{Name}, LastName:{LastName}, Surname: {SurName}, Date of Birth : {DateOfBirth.ToShortDateString()}, Age: {Age},WorkExp: {WorkExp.TotalDays / 30}, Seniority: {Seniority}";
        }
    }
}
