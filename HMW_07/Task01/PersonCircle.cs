using System.Collections.Generic;

namespace Task01
{
    public class PersonCircle
    {
        List<int> persons;

        public PersonCircle(int n)
        {
            persons = CreatePersons(n);
        }

        private List<int> CreatePersons(int n)
        {
            List<int> persons = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                persons.Add(i);
            }
            return persons;
        }

        public int RemovePersons()
        {
            do
            {
                for (int i = 0; i < this.persons.Count ; i++)
                {
                    if((i+1) % 2 == 0)
                    {
                        this.persons.RemoveAt(i);
                    }
                }
            }
            while (this.persons.Count != 1);
            return this.persons[0];
        }
    }
}
