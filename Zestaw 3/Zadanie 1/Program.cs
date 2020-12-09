using System;

namespace Zadanie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laboratorium 3, zadanie 1");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");

            Test test_wielomianu = new Test();

            test_wielomianu.wprowadz_dane();
            test_wielomianu.oblicz_pierwastki();
        }
    }
}
