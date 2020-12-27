using System;

namespace Zadanie_1
{
    public class Person : IComparable
    {
        private string Name { get; set; }
        public int Age { get; set; }

        public Person(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public int CompareTo(object? obj)
        {
            Person otherPerson = (Person)obj;
            if (this.Age == otherPerson.Age)
            {
                return this.Name.CompareTo(otherPerson.Name);
            }
            else
            {
                return this.Age.CompareTo(otherPerson.Age);
            }
        }

        public override string ToString()
        {
            return this.Name + ", wiek: " + this.Age;
        }
    }
}