using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Zadanie_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

            //PrezentacjaWGrupach();
            //LaczenieZbiorowDanych();
            //LaczenieOperatoremJoin();
            //MozliwaModyfikacjaDanychZrodla();
        }

        private static void Menu()
        {
            var quit = false;

            while (!quit)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Dodaj osobę do listy");
                Console.WriteLine("2) Usuń osobę z listy");
                Console.WriteLine("3) Wyświetl wszystkie osoby");
                Console.WriteLine("4) Wyświetl wszystkie osoby pełnoletnie");
                Console.WriteLine("5) Analizuj dane");
                Console.WriteLine("6) Najmłodsza pełnoletnia osoba");
                Console.WriteLine("7) Sprawdź czy osoba jest pełnoletnia");
                Console.WriteLine("9) Wyświetl autora");
                Console.WriteLine("\n0) Wyjście");
                Console.Write("\nWybór:          \b\b\b\b\b\b\b\b\b");
                var opcja = Console.ReadLine();
                switch (opcja)
                {
                    case "0":
                        quit = true;
                        break;
                    case "1":
                        DodajOsobe();
                        WyczyscEkran();
                        break;
                    case "2":
                        UsunOsobe();
                        WyczyscEkran();
                        break;
                    case "3":
                        WyswietlWszystkieOsoby();
                        WyczyscEkran();
                        break;
                    case "4":
                        PobieranieDanych();
                        WyczyscEkran();
                        break;
                    case "5":
                        AnalizaPobranychDanych();
                        WyczyscEkran();
                        break;
                    case "6":
                        WyborElementu();
                        WyczyscEkran();
                        break;
                    case "7":
                        WeryfikowanieDanych();
                        WyczyscEkran();
                        break;
                    case "9":
                        WyswietlDaneKomputera();
                        WyczyscEkran();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void WyswietlWszystkieOsoby()
        {
            Console.WriteLine("Lista wszystkich osób:");
            foreach (var person in listOfPersons)
            {
                Console.WriteLine("{0,0}. {1,0} {2,-25} \twiek: {3,0} \ttelefon: {4,0}", person.Id, person.Name, person.FamilyName, person.Age, person.Phone);
            }
        }

        private static void UsunOsobe()
        {
            Console.WriteLine("Wprowadź ID osoby, która ma zostać usunięta z listy:");

            Console.Write("ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("ID: ");
            }
            listOfPersons.Remove(listOfPersons.FirstOrDefault(per => per.Id == id));
        }

        private static void DodajOsobe()
        {
            Console.WriteLine("Wprowadź dane nowej osoby:");

            Console.Write("ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("ID: ");
            }

            Console.Write("Imię: ");
            var name = Console.ReadLine();

            Console.Write("Nazwisko: ");
            var familyName = Console.ReadLine();

            Console.Write("Wiek: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Wiek: ");
            }

            Console.Write("Telefon: ");
            int phone;
            while (!int.TryParse(Console.ReadLine(), out phone))
            {
                Console.Write("Telefon: ");
            }

            listOfPersons.Add(new Person() { Id = id, Name = name, FamilyName = familyName, Age = age, Phone = phone });
        }

        public static void WyczyscEkran()
        {
            Console.ReadLine();
            Console.SetCursorPosition(0, 6);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("                                                                                                                      ");
            }
        }

        static List<Person> listOfPersons =
            new List<Person>
            {
                new Person { Id = 1, Name = "Jan", FamilyName = "Kabałkiewicz", Phone = 1232024, Age = 39 },
                new Person { Id = 2, Name = "Andrzej", FamilyName = "Kabałkiewicz", Phone = 1232020, Age = 29 },
                new Person { Id = 3, Name = "Maciej", FamilyName = "Babałkiewicz", Phone = 1232021, Age = 49 },
                new Person { Id = 4, Name = "Witold", FamilyName = "Mabałkiewicz", Phone = 1232024, Age = 26 },
                new Person { Id = 5, Name = "Adam", FamilyName = "Kabałkiewicz", Phone = 1232023, Age = 13 },
                new Person { Id = 6, Name = "Ewa", FamilyName = "Mabałkiewicz", Phone = 1232025, Age = 17 },

            };
        private static void PobieranieDanych()
        {
            var listOfAdults = from person in listOfPersons
                               where person.Age >= 18
                               orderby person.Age
                               select person;
            List<Person> sublist = listOfAdults.ToList<Person>();

            //Console.WriteLine("\tPobieranie danych (filtrowanie i sortowanie)");

            Console.WriteLine("Lista osób pełnoletnich - wer. 1");
            foreach (var person in listOfAdults)
            {
                Console.WriteLine($"{person.Name} {person.FamilyName},\twiek: {person.Age}");
            }

            Console.WriteLine("\nLista osób pełnoletnich - wer.2");
            foreach (var person in sublist)
            {
                Console.WriteLine($"{person.Name} {person.FamilyName},\twiek: {person.Age}");
            }
        }

        private static void AnalizaPobranychDanych()
        {
            var listOfAdults = from person in listOfPersons
                               where person.Age >= 18
                               orderby person.Age
                               select person;

            //Console.WriteLine("\n\tAnaliza potrzebnych danych");

            Console.WriteLine($"Wiek osoby najstarszej: {listOfAdults.Max(person => person.Age)}");

            Console.WriteLine($"Średni wiek osób pełnoletnich: {listOfAdults.Average(person => person.Age)}");

            Console.WriteLine($"Suma lat osób pełnoletnich: {listOfAdults.Sum((person => person.Age))}");
        }

        private static void WyborElementu()
        {
            var listOfAdults = from person in listOfPersons
                               where person.Age >= 18
                               orderby person.Age
                               select person;

            //Console.WriteLine("\n\tWybór elementu");

            var youngestPerson = listOfAdults
                .Single((person1 => (person1.Age == listOfAdults
                    .Min(person2 => person2.Age))));

            Console.WriteLine($"Najmłodsza osoba pełnoletnia: {youngestPerson.Name} " +
                              $"{youngestPerson.FamilyName},\twiek - {youngestPerson.Age}");
        }

        private static void WeryfikowanieDanych()
        {
            var listOfAdults = from person in listOfPersons
                               where person.Age >= 18
                               orderby person.Age
                               select person;
            //Console.WriteLine("\n\tWeryfikowanie danych");
            Console.Write("Imię osoby do sprawdzenia: ");
            var name = Console.ReadLine();
            bool doesContain = listOfAdults.Any(person => (person.Name == name));

            Console.WriteLine($"Czy jest osoba pełnoletnia o imieniu {name}: {doesContain}");
        }

        private static void PrezentacjaWGrupach()
        {
            var sameFailyName = from person in listOfPersons
                                group person by person.FamilyName into familyGroup
                                select familyGroup;

            Console.WriteLine("\n\tPrezentacja w grupach");
            Console.WriteLine("Lista osób pogrupowanych wg nazwisk");

            foreach (var grupa in sameFailyName)
            {
                Console.WriteLine($"\tGrupa o nazwisku: {grupa.Key}");
                foreach (var person in grupa)
                {
                    Console.WriteLine($"\t\t{person.Name} {person.FamilyName}");
                }
            }
            Console.WriteLine();
        }

        private static void LaczenieZbiorowDanych()
        {
            Console.WriteLine("\n\tŁączenie zbiorów danych");
            Console.WriteLine("Lista osób pełnoletnich i kobiet");

            var listOfAdults = from person in listOfPersons
                               where person.Age >= 18
                               orderby person.Age
                               select new { person.Name, person.FamilyName, person.Age };

            var listOfWomens = from person in listOfPersons
                               where person.Name.EndsWith("a")
                               select new { person.Name, person.FamilyName, person.Age };

            var newList = listOfAdults.Concat(listOfWomens).Distinct();

            foreach (var person in newList)
            {
                Console.WriteLine($"{person.Name} {person.FamilyName},\twiek: {person.Age}");
            }
            Console.WriteLine();
        }

        private static void LaczenieOperatoremJoin()
        {
            var listOfPhones = from person in listOfPersons
                               select new { person.Id, person.Phone };

            var listOfNames = from person in listOfPersons
                              select new { person.Id, person.Name, person.FamilyName };

            var newList = from pp in listOfPhones
                          join nn in listOfNames on pp.Id equals nn.Id
                          select new
                          {
                              pp.Id,
                              nn.Name,
                              nn.FamilyName,
                              pp.Phone
                          };

            Console.WriteLine("\n\tŁączenie danych z różnych źródeł operatorem join");
            Console.WriteLine("Lista osób z numerami telefonów");

            foreach (var person in newList)
            {
                Console.WriteLine($"{person.Id}.{person.Name} {person.FamilyName},\ttel: {person.Phone}");
            }
        }

        private static void MozliwaModyfikacjaDanychZrodla()
        {
            Console.WriteLine("\n\tMożliwa modyfikacja danych źródła");

            var listOfAdults = from person in listOfPersons
                               where person.Age >= 18
                               orderby person.Age
                               select person;

            Console.WriteLine("Kolekcja-źródło:");
            foreach (var person in listOfAdults)
            {
                Console.WriteLine($"{person.Name} {person.FamilyName},\twiek: {person.Age}");
            }
            Console.WriteLine();

            var newListOfAdults = from person in listOfPersons
                                  where person.Age >= 18
                                  orderby person.Age
                                  select person;

            Person firstOnList = newListOfAdults.First<Person>();
            firstOnList.Name = "Tomasz";
            firstOnList.FamilyName = "Tabakiewicz";
            firstOnList.Age = 30;

            Console.WriteLine("Źródło - lista 1 po zmianie w lista 2:");
            foreach (var person in listOfAdults)
            {
                Console.WriteLine($"{person.Name} {person.FamilyName},\twiek: {person.Age}");
            }
            Console.WriteLine();
        }

        private static void WyswietlDaneKomputera()
        {
            Console.WriteLine("Laboratorium 6, zadanie 5");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }
    }
}
