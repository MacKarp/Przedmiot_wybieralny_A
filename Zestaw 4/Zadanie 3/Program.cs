using System;
using System.Collections.Generic;

namespace Zadanie_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laboratorium 4, zadanie 3");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");


            Console.WriteLine(Max(new int[] { 1, 3, 5, 7, 4, 2 }));
            Console.WriteLine(Max(new string[] { "alicja", "ma", "kota" }));
            Console.WriteLine();
            Demo2Collections();
        }

        public static T Max<T>(T[] tab) where T : IComparable<T>
        {
            T max = tab[0];
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[i].CompareTo(max) > 0)
                {
                    max = tab[i];
                }
            }

            return max;
        }

        public static void DemoQueue()
        {
            Queue<string> queueS = new Queue<string>();
            Console.WriteLine("Demo kolekcji Queue<string>:");
            queueS.Enqueue("jeden");
            queueS.Enqueue("dwa");
            queueS.Enqueue("trzy");

            foreach (var s in queueS)
            {
                Console.WriteLine(s);
            }

            while (queueS.Count != 0)
            {
                Console.WriteLine(queueS.Dequeue());
            }

            Console.WriteLine("Kolekcja Queue po usunięciu:");
            foreach (var s in queueS)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Dodaje elementy: 'cztery', 'pięć' i 'sześć' do queueS");
            queueS.Enqueue("cztery");
            queueS.Enqueue("pięć");
            queueS.Enqueue("sześć");

            Console.WriteLine("Czy queueS zawiera(Contains()) element 'pięć'? " + queueS.Contains("pięć"));
            Console.WriteLine("Czy queueS zawiera(Contains()) element 'osiem'? " + queueS.Contains("osiem"));
            Console.WriteLine("Peek() zwraca pierwszy element ale go nie usuwa: " + queueS.Peek());
            Console.WriteLine("queueS to zastosowaniu Peek()");
            foreach (var s in queueS)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Clear() czyści całą kolejkę");
            queueS.Clear();
            foreach (var s in queueS)
            {
                Console.WriteLine(s);
            }
        }

        public static void DemoDictionary()
        {
            var dict = new Dictionary<int, string>();
            dict.Add(5, "Adam");
            dict.Add(3, "Jola");
            dict.Add(8, "pies");
            dict.Add(4, "kot");

            Console.WriteLine("Demo kolekcji Dictionary<int, string>:");
            foreach (var elem in dict)
            {
                Console.WriteLine(elem);
            }

            Console.WriteLine("keys:");
            foreach (var key in dict.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("Dostęp do elementu za pomocą klucza jest szybki:");
            Console.WriteLine(dict.GetValueOrDefault(8));
            Console.WriteLine(dict.GetValueOrDefault(1));
            Console.WriteLine("Remove() zwraca: " + dict.Remove(5));
            Console.WriteLine("TryAdd() zwraca: " + dict.TryAdd(8, "co?"));

            Console.WriteLine("Dodaje nowe wpisy do słownika");
            dict.Add(13, "Tomasz");
            dict.Add(15, "królik");
            dict.Add(10, "Magdalena");
            dict.Add(12, "renifer");
            foreach (var elem in dict)
            {
                Console.WriteLine(elem);
            }

            Console.WriteLine("Czy dict zawieraContainsKey()) klucz '10'? " + dict.ContainsKey(10));
            Console.WriteLine("Czy dict zawiera(ContainsKey()) klucz '14'? " + dict.ContainsKey(14));
            Console.WriteLine("Czy dict zawiera(ContainsValue()) wartość 'chomik'? " + dict.ContainsValue("chomik"));
            Console.WriteLine("Czy dict zawiera(ContainsValue()) wartość 'renifer'? " + dict.ContainsValue("renifer"));
            Console.WriteLine("Clear() czyści cały słownik");
            dict.Clear();
            foreach (var elem in dict)
            {
                Console.WriteLine(elem);
            }
        }

        public static void Demo2Collections()
        {
            DemoQueue();
            Console.WriteLine();
            DemoDictionary();
        }
    }
}
