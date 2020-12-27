using System;
using System.Collections.Generic;

namespace Zadanie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laboratorium 4, zadanie 1");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");

            List<Person> lista = new List<Person>();
            lista.Add(new Person("Anna", 43));
            lista.Add(new Person("Tomasz", 55));
            lista.Add(new Person("Magdalena", 18));
            lista.Add(new Person("Anna", 21));
            lista.Add(new Person("Justyna", 21));
            lista.Add(new Person("Stanisław", 55));
            lista.Add(new Person("Justyna", 19));

            Console.WriteLine("Lista przed sortowaniem: ");
            foreach (var person in lista)
            {
                Console.WriteLine(person.ToString());
            }

            lista.Sort();
            Console.WriteLine("\nLista po sortowaniu: ");
            foreach (var person in lista)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
