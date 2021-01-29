using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie_4
{
    class Program
    {
        static void Main(string[] args)
        {
            WyswietlDaneKomputera();
            CallerWithContinuationTask();
            Console.WriteLine("Koniec main, metody async jeszcze działają.");
            Console.ReadLine();
        }

        private async static void CallerWithContinuationTask()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            Task<string> t1 = GreetingAsync("Ola", 5000);
            Task<string> t2 = GreetingAsync("Jola", 7000);
            Task<string> t3 = GreetingAsync("Karol", 3000);
            await t1.ContinueWith(t =>
            {
                string result1 = t.Result;
                Console.WriteLine(result1 + "\tdługość napisu: " + result1.Length);
            });

            await t2.ContinueWith(t =>
            {
                string result2 = t.Result;
                Console.WriteLine(result2 + "\tdługość napisu: " + result2.Length);
            });

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
            Console.WriteLine("Laboratorium 6, zadanie 4");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }
    }
}
