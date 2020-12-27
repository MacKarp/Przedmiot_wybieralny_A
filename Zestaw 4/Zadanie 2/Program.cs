using System;
using System.ComponentModel;

namespace Zadanie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laboratorium 4, zadanie 2");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");

            Para<string>[] pstr = new Para<string>[7];
            pstr[0] = new Para<string>("Ola", "Olowska");
            pstr[1] = new Para<string>("Uta", "Utowska");
            pstr[2] = new Para<string>("Web", "Webowski");
            pstr[3] = new Para<string>("Ewa", "Ebowska");
            pstr[4] = new Para<string>("Jaś", "Jasiński");
            pstr[5] = new Para<string>("Jaś", "Janowicz");
            pstr[6] = new Para<string>("Ola", "Olowicz");

            Console.WriteLine("\nPara<String> przed sortowaniem");
            foreach (var para in pstr)
            {
                Console.WriteLine($"\t{para.ToString()}");
            }

            Array.Sort(pstr);
            Console.WriteLine("\nPara<String> po sortowaniu");
            foreach (var para in pstr)
            {
                Console.WriteLine($"\t{para.ToString()}");
            }

        }
    }
}
