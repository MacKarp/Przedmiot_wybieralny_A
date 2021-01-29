using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            WyswietlDaneKomputera();
            MultipleAsyncMethodsWithWhenAll();
            Console.WriteLine("Koniec main, metody async jeszcze działają.");
            Console.ReadLine();
        }

        private async static void MultipleAsyncMethodsWithWhenAll()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            Task<string> t1 = GreetingAsync("Ola", 5000);
            Task<string> t2 = GreetingAsync("Jola", 7000);
            Task<string> t3 = GreetingAsync("Karol", 3000);
            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine($"Zakończyły się trzy metody{Environment.NewLine}");
            Console.WriteLine($"Wynik metody dotępny we właściwości Result{Environment.NewLine}");

            Console.WriteLine($"m1: {t1.Result}\nm2: {t2.Result}\nm3: {t3.Result}");

            sw.Stop();
            Console.WriteLine($"Upływ czasu: {sw.Elapsed}");
        }

        private static Task<string> GreetingAsync(string name, int delay)
        {
            return Task.Run<string>(() =>
            {
                Thread.Sleep(delay);
                return string.Format($"Witaj {name}!");
            });
        }

        private static void WyswietlDaneKomputera()
        {
            Console.WriteLine("Laboratorium 6, zadanie 2");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }
    }
}
