using System;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            var indeks = 0;
            Console.Write("Witaj!\nPodaj swoje imię: ");
            var name = Console.ReadLine();
            Console.Write("Dziękuję!\nA teraz podaj swój numer indeksu: ");
            try
            {
                indeks = Int32.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}! Podałeś nieprawidłowy numer indeksu! Przerywam!", name);
                return;
            }
            Console.WriteLine("Witaj! {0}, {1}!", name, indeks);
        }
    }
}
