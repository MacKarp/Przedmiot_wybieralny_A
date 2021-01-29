using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie_3
{
    class Program
    {
        static void Main(string[] args)
        {
            WyswietlDaneKomputera();
            MultipleAsyncMethodsWithWhenAll();
            Console.ReadLine();
        }

        private async static void MultipleAsyncMethodsWithWhenAll()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            Task<string> t1 = GreetingAsync("Ola", 5000);
            Task<string> t2 = GreetingAsync("Jola", 7000);
            Task<string> t3 = GreetingAsync("Karol", 3000);

            string result = await Task.WhenAny(t1, t2, t3).Result;

            Console.WriteLine($"Koniec metody 'najszybszej'\nWynik:{result}");
            stopwatch.Stop();
            Console.WriteLine($"Upływ czasu: {stopwatch.Elapsed}");
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
            Console.WriteLine("Laboratorium 6, zadanie 3");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }
    }
}
