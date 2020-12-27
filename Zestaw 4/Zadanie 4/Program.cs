using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laboratorium 4, zadanie 4");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");

            var slownik = new Dictionary<string, List<string>>();
            slownik.Add("Abstrakcja", new List<string>() { "Abstraction", "Abstract" });
            slownik.Add("Fabryka", new List<string>() { "Factory", "Works" });
            slownik.Add("Fotografia", new List<string>() { "Photo", "Photography" });
            slownik.Add("Mechanizm", new List<string>() { "Mechanism", "Works", "Factory", "Device" });
            slownik.Add("Zdjęcie", new List<string>() { "Photography", "Photo" });
            slownik.Add("Zakład", new List<string>() { "Workplace", "Factory" });

            Console.WriteLine("Polskie słowa w słowniku: ");
            foreach (var slowo in slownik)
            {
                Console.WriteLine("\t" + slowo.Key);
            }

            Console.WriteLine("\nAngielskie słowa w słowniku:");
            foreach (var slowo in slownik)
            {
                Console.WriteLine("\t" + slowo.Value[0]);
            }

            while (true)
            {
                Console.Write("Wpisz słowo, kótre chcesz przetłumaczyć: ");
                string slowoDoTlumaczenia = Console.ReadLine();
                Console.WriteLine("Tłumaczenie słowa " + slowoDoTlumaczenia + ":");
                if (slownik.ContainsKey(slowoDoTlumaczenia))
                {
                    foreach (var slowo in slownik[slowoDoTlumaczenia])
                    {
                        Console.WriteLine("\t" + slowo);
                    }
                }
                else
                {
                    foreach (var slowo in slownik)
                    {
                        if (slowo.Value.Any(s => s.Contains(slowoDoTlumaczenia)))
                        {
                            Console.WriteLine("\t" + slowo.Key);
                        }
                    }
                }

            }
        }
    }
}
