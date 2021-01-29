using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Zadanie_1
{
    class Program
    {
        //private const string url = "http://pwsz.legnica.edu.pl";

        static async Task Main(string[] args)
        {
            WyswietlDaneKomputera();

            Console.Write("Podaj adres www: ");
            var url = Console.ReadLine();
            int znak;
            Console.Write("Podaj ilość znaków do wczytania: ");

            while (!int.TryParse(Console.ReadLine(), out znak))
            {
                Console.Write("Podaj ilość znaków do wczytania: ");
            }

            //SynchronizedAPI(url, znak);
            AsynchronizedPattern(url, znak);
            EventBasedAsyncPattern(url, znak);
            await TaskBasedAsyncPatterAsync(url, znak);
            Console.ReadLine();
        }

        private static async Task TaskBasedAsyncPatterAsync(string url, int znak)
        {
            string name = nameof(TaskBasedAsyncPatterAsync);
            Console.WriteLine("\t" + name);

            using (var client = new WebClient())
            {
                string content = await client.DownloadStringTaskAsync(url);
                Console.WriteLine(content.Substring(0, znak));
                Console.WriteLine("koniec " + name + Environment.NewLine);
            }
        }

        private static void EventBasedAsyncPattern(string url, int znak)
        {
            string name = nameof(EventBasedAsyncPattern);
            Console.WriteLine("\t" + name);

            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += (sender, e) =>
                {
                    Console.WriteLine(e.Result.Substring(0, znak));
                };
                client.DownloadStringAsync(new Uri(url));
                Console.WriteLine("koniec " + name + Environment.NewLine);
            }
        }

        private static void AsynchronizedPattern(string url, int znak)
        {
            string name = nameof(AsynchronizedPattern);
            Console.WriteLine("\t" + name);
            WebRequest request = WebRequest.Create(url);
            IAsyncResult result = request.BeginGetResponse(ReadResponse, null);

            void ReadResponse(IAsyncResult ar)
            {
                using (WebResponse respone = request.EndGetResponse(ar))
                {
                    Stream stream = respone.GetResponseStream();
                    var reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content.Substring(0, znak));
                    Console.WriteLine("koniec " + name + Environment.NewLine);
                }
            }
        }

        private static void SynchronizedAPI(string url, int znak)
        {
            string name = nameof(SynchronizedAPI);
            Console.WriteLine("\t" + name);
            using (var client = new WebClient())
            {
                string content = client.DownloadString(url);
                Console.WriteLine(content.Substring(0, znak));
            }
            Console.WriteLine("koniec " + name + Environment.NewLine);
        }

        private static void WyswietlDaneKomputera()
        {
            Console.WriteLine("Laboratorium 6, zadanie 1");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }
    }
}
