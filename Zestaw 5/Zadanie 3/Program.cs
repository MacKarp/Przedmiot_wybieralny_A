using System;
using Newtonsoft.Json;

namespace Zadanie_3
{
    class Program
    {
        public static void Main()
        {
            Menu();
        }
        private static void WyswietlDaneKomputera()
        {
            Console.WriteLine("Laboratorium 5, zadanie 3");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }

        public static void Menu()
        {
            var quit = false;
            var serial = "";
            Person[] listaOsob =
            {
                new Person("Karolina", 33),
                new Person("Alicja", 35),
                new Person("Alicja", 30),
                new Person("Karol", 33),
                new Person("Witold", 28),
            };

            while (!quit)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Dodaj osobę");
                Console.WriteLine("2) Wyświetl wszystkie osoby");
                Console.WriteLine("3) Sortuj i wyświetl według imienia");
                Console.WriteLine("4) Sortuj i wyświetl według wieku");
                Console.WriteLine("5) Serializuj i wyświetl");
                Console.WriteLine("6) Deserializuj i wyświetl");
                Console.WriteLine("7) Wyświetl autora");
                Console.WriteLine("\n0) Wyjście");
                Console.Write("\nWybór:          \b\b\b\b\b\b\b\b\b");
                var opcja = Console.ReadLine();
                switch (opcja)
                {
                    case "0":
                        quit = true;
                        break;
                    case "1":
                        Array.Resize(ref listaOsob, listaOsob.Length + 1);
                        listaOsob[listaOsob.Length - 1] = DodajOsobe();
                        WyczyscEkran();
                        break;
                    case "2":
                        ShowPersons("Lista osób:", listaOsob);
                        WyczyscEkran();
                        break;
                    case "3":
                        BubbleSort(listaOsob, (x, y) => x.Name.CompareTo(y.Name) < 0);
                        ShowPersons("Lista osób posortowana według imienia:", listaOsob);
                        WyczyscEkran();
                        break;
                    case "4":
                        BubbleSort(listaOsob, (x, y) => x.Age < y.Age);
                        ShowPersons("Lista osób posortowana według wieku:", listaOsob);
                        WyczyscEkran();
                        break;
                    case "5":
                        serial = Serializuj(listaOsob);
                        Console.WriteLine(serial);
                        WyczyscEkran();
                        break;
                    case "6":
                        var temp = Deserializuj(serial);
                        if (temp == null)
                        {
                            Console.WriteLine("Najpierw serializuj!");
                            WyczyscEkran();
                            break;
                        }
                        else
                        {
                            listaOsob = temp;
                            ShowPersons("Po deserializacji:", listaOsob);
                            WyczyscEkran();
                            break;
                        }

                    case "7":
                        WyswietlDaneKomputera();
                        WyczyscEkran();
                        break;
                    default:
                        break;
                }
            }
        }

        private static Person[] Deserializuj(String serial)
        {
            return JsonConvert.DeserializeObject<Person[]>(serial);
        }

        private static String Serializuj(Person[] arr)
        {
            return JsonConvert.SerializeObject(arr);
        }

        private static Person DodajOsobe()
        {
            Console.WriteLine("Dodaj nową osobę:");
            Console.Write("Podaj imię: ");
            var imie = Console.ReadLine();
            Console.Write("Podaj wiek: ");
            int wiek = 0;
            try
            {
                wiek = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Nieprawidłowa wartość\n");
            }
            return new Person(imie, wiek);
        }

        public static void WyczyscEkran()
        {
            Console.ReadLine();
            Console.SetCursorPosition(0, 6);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("                                                                                                                                                                  ");
            }
        }
        public static void BubbleSort(Person[] arr, Func<Person, Person, bool> lessThan)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!lessThan(arr[j], arr[j + 1]))
                    {
                        Person p = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = p;
                    }
                }
            }
        }

        public static void ShowPersons(string comment, Person[] arr)
        {
            Console.WriteLine(comment);
            foreach (Person p in arr)
            {
                Console.WriteLine(p);
            }
        }
    }
}
