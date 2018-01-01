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
            bool remove = false;
            while (this.persons.Count != 1)
            {
                for (int i = 0; i < persons.Count; i++)
                {
                    if (remove)
                    {
                        persons.RemoveAt(i--);
                    }

                    remove = !remove;
                }
            }
            return this.persons[0];
        }
    }
}
