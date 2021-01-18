using System;
using System.Collections.Generic;

namespace Zadanie_5
{
    class Program
    {
        private static void WyswietlDaneKomputera()
        {
            Console.WriteLine("Laboratorium 5, zadanie 5");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            var quit = false;
            var dealer = new CarDealer();
            var clientList = new List<Consumer>();
            clientList.Add(new Consumer("Michał"));
            dealer.NewCarInfo += clientList[0].NewCarIsHere;
            clientList.Add(new Consumer("Ela"));
            dealer.NewCarInfo += clientList[1].NewCarIsHere;
            clientList.Add(new Consumer("Kalina"));
            dealer.NewCarInfo += clientList[2].NewCarIsHere;
            while (!quit)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Dodaj klienta");
                Console.WriteLine("2) Wyświetl listę klientów");
                Console.WriteLine("3) Usuń klienta");
                Console.WriteLine("4) Dodaj nowy samochód");
                Console.WriteLine("5) Wyświetl autora");
                Console.WriteLine("\n0) Wyjście\n");
                if (clientList.Count == 0)
                {
                    Console.WriteLine("Nikogo nie ma w salonie!");
                }
                var opcja = Console.ReadKey(true).KeyChar;
                switch (opcja)
                {
                    case '0':
                        quit = true;
                        break;
                    case '1':
                        var newConsumer = newClient();
                        dealer.NewCarInfo += newConsumer.NewCarIsHere;
                        clientList.Add(newConsumer);
                        WyczyscEkran();
                        break;
                    case '2':
                        Console.WriteLine("Lista klientów: ");
                        int i = 1;
                        foreach (var consumer in clientList)
                        {
                            Console.WriteLine(i + ": " + consumer.ToString());
                            i++;
                        }
                        WyczyscEkran();
                        break;
                    case '3':
                        Console.Write("Podaj numer klienta, który wyszedł salonu: ");
                        try
                        {
                            int t_index = int.Parse(Console.ReadLine());
                            dealer.NewCarInfo -= clientList[t_index - 1].NewCarIsHere;
                            Console.WriteLine("Klient " + clientList[t_index - 1].ToString() + " wyszedł z salonu");
                            clientList.RemoveAt(t_index - 1);
                        }
                        catch
                        {
                            Console.WriteLine("Nieprawidłowy numer osoby!");
                        }
                        WyczyscEkran();
                        break;
                    case '4':
                        Console.Write("Podaj nazwę nowego samochodu: ");
                        var t = Console.ReadLine();
                        dealer.RaiseNewCarInfo(t);
                        WyczyscEkran();
                        break;
                    case '5':
                        WyswietlDaneKomputera();
                        WyczyscEkran();
                        break;
                    default:
                        break;
                }
            }
        }

        private static Consumer newClient()
        {
            Console.Write("Podaj imię klienta: ");
            var t = Console.ReadLine();
            return new Consumer(t);
        }

        public static void WyczyscEkran()
        {
            Console.ReadLine();
            Console.SetCursorPosition(0, 6);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("                                                                        ");
            }
        }
    }
}
