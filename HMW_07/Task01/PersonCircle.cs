namespace Task01
{
    using System.Collections.Generic;

    public class PersonCircle
    {
        private readonly List<int> persons;

        public PersonCircle(int n)
        {
            this.persons = this.CreatePersons(n);
        }

        public int RemovePersons()//todo pn придираюсь, но можно было погуглить более оптимальное решение. Задача Иосифа.
        {
            bool remove = false;
            while (this.persons.Count != 1)
            {
                for (int i = 0; i < this.persons.Count; i++)
                {
                    if (remove)
                    {
                        this.persons.RemoveAt(i--);
                    }

                    remove = !remove;
                }
            }

            return this.persons[0];
        }

        private List<int> CreatePersons(int n)
        {
            List<int> personsList = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                personsList.Add(i);
            }

            return personsList;
        }
    }
}
