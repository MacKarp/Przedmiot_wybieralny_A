using System;

namespace Zadanie_1
{
    class Program
    {
        public delegate bool LessThan(Person a, Person b);

        public static void BubbleSort(Person[] arr, LessThan lessThan)
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

        public static bool LessName(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name) < 0;
        }

        public static bool LessAge(Person x, Person y)
        {
            return x.Age < y.Age;
        }

        public static void ShowPerson(string comment, Person[] arr)
        {
            Console.WriteLine("\n" + comment);
            foreach (var person in arr)
            {
                Console.WriteLine(person);
            }
        }

        static void Main(string[] args)
        {
            Menu();
        }

        private static void WyswietlDaneKomputera()
        {
            Console.WriteLine("Laboratorium 5, zadanie 1");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }

        public static void Menu()
        {
            var quit = false;
            Person[] listaOsob = {new Person("Karolina", 33),
                new Person("Alicja", 35),
                new Person("Alicja", 30),
                new Person("Karol", 33),
                new Person("Witold", 28)};

            while (!quit)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Dodaj osobę");
                Console.WriteLine("2) Wyświetl wszystkie osoby");
                Console.WriteLine("3) Sortuj i wyświetl według imienia");
                Console.WriteLine("4) Sortuj i wyświetl według wieku");
                Console.WriteLine("5) Wyświetl autora");
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
                        ShowPerson("Lista osób:", listaOsob);
                        WyczyscEkran();
                        break;
                    case "3":
                        BubbleSort(listaOsob, LessName);
                        ShowPerson("Lista osób posortowana według imienia:", listaOsob);
                        WyczyscEkran();
                        break;
                    case "4":
                        BubbleSort(listaOsob, LessAge);
                        ShowPerson("Lista osób posortowana według wieku:", listaOsob);
                        WyczyscEkran();
                        break;
                    case "5":
                        WyswietlDaneKomputera();
                        WyczyscEkran();
                        break;
                    default:
                        break;
                }
            }
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
                Console.WriteLine("                                                                        ");
            }
        }
    }
}
