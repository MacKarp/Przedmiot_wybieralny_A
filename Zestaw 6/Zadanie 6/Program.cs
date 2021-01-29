using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zadanie_6
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateTheDatabaseAsync(false);
            await Menu();
        }

        private static async Task CreateTheDatabaseAsync(bool print)
        {
            using (var context = new BookContext())
            {
                bool created = await context.Database.EnsureCreatedAsync();
                string creationInfo = created ? "została utworzona" : "istnieje";
                if (print)
                {
                    Console.WriteLine($"baza danych {creationInfo}");
                }

                if (created && print)
                {
                    Console.Write("Czy chcesz dodać domyślne książki do bazy danych[t/n]: ");
                    if (Console.ReadLine().ToLower() == "t")
                    {
                        await AddDefualtBooksAsync();
                    }
                }
            }
        }

        private static async Task DeleteDatabaseAsync()
        {
            Console.Write("Usunąć bazę danych?[t/n] ");
            string input = Console.ReadLine();
            if (input.ToLower() == "t")
            {
                using (var context = new BookContext())
                {
                    bool del = await context.Database.EnsureDeletedAsync();
                    string deleteInfo = del ? "została usunięta" : "nie została usunięta";
                    Console.WriteLine($"baza danych {deleteInfo}");
                }
            }
        }

        private static async Task AddDefualtBooksAsync()
        {
            using (var context = new BookContext())
            {
                var b1 = new Book { Title = "Azure for Architects", Publisher = "Packt Publishing" };
                var b2 = new Book { Title = "Azure Networking Cookbook", Publisher = "Packt Publishing" };
                var b3 = new Book { Title = "Azure Serverless Computing Cookbook", Publisher = "Packt Publishing" };
                var b4 = new Book { Title = "Angular w akcji", Publisher = "Helion SA" };

                await context.Books.AddRangeAsync(b1, b2, b3, b4);

                int records = await context.SaveChangesAsync();
                Console.WriteLine($"dodano: {records} rekord(-ów)");
            }
            Console.WriteLine();
        }

        private static async Task AddBookAsync()
        {
            Console.WriteLine("\nWprowadź nową książkę do bazy danych:");
            Console.Write("Tytuł: ");
            var title = Console.ReadLine();
            Console.Write("Wydawca: ");
            var publisher = Console.ReadLine();
            using (var context = new BookContext())
            {

                await context.Books.AddAsync(new Book { Title = title, Publisher = publisher });
                await context.SaveChangesAsync();
            }
        }

        private static async Task ReadBookAsync()
        {
            Console.WriteLine("\nLista wszystkich książek znajdujących się w bazie danych:");
            using (var context = new BookContext())
            {
                List<Book> books = await context.Books.ToListAsync();
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.BookId}. {book.Title}, {book.Publisher}");
                }
            }
            Console.WriteLine();
        }

        private static async Task QueryBooks1Async()
        {
            string title = new string("");
            while (title.Length == 0)
            {
                Console.Write("Wyszukaj wszystkie książki zawierające w tytule: ");
                title = Console.ReadLine();
            }

            using (var context = new BookContext())
            {
                List<Book> books = await context.Books.Where(b => b.Title.ToLower().Contains(title.ToLower())).ToListAsync();
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title}, {book.Publisher}");
                }
            }
            Console.WriteLine();
        }

        private static async Task QueryBooks2Async()
        {
            string publisher = new string("");
            while (publisher.Length == 0)
            {
                Console.Write("Wyszukaj wszystkie książki wydawcy: ");
                publisher = Console.ReadLine();
            }
            using (var context = new BookContext())
            {
                var books = await (from book in context.Books
                                   where book.Publisher.ToLower().Contains(publisher.ToLower())
                                   select book).ToListAsync();
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title}, {book.Publisher}");
                }
            }
            Console.WriteLine();
        }

        private static async Task UpdateBookAsync()
        {
            Console.Write("\nAktualizacja książki ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("ID: ");
            }
            using (var context = new BookContext())
            {
                int records = 0;
                Book book = await context.Books.Where(b => b.BookId == id).FirstOrDefaultAsync();
                if (book != null)
                {
                    Console.Write("Podaj nowy tytuł książki: ");
                    var newTitle = Console.ReadLine();
                    if (newTitle.Length != 0)
                    {
                        book.Title = newTitle;
                    }
                    Console.Write("Podaj nowego wydawcę książki: ");
                    var newPublisher = Console.ReadLine();
                    if (newPublisher.Length != 0)
                    {
                        book.Publisher = newPublisher;
                    }

                    records = await context.SaveChangesAsync();
                }
                Console.WriteLine($"zmodyfikowano {records} rekord(-ów)");
            }
            Console.WriteLine();
        }

        private static async Task DeleteBooksAsync()
        {
            Console.Write("\nUsuń książkę o ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("ID: ");
            }

            using (var context = new BookContext())
            {
                int records = 0;
                Book book = await context.Books.Where(b => b.BookId == id).FirstOrDefaultAsync();
                if (book != null)
                {
                    context.Books.Remove(book);
                }
                records = await context.SaveChangesAsync();
                Console.WriteLine($"usunięto {records} rekord(-ów)");
            }
            Console.WriteLine();
        }

        private static async Task Menu()
        {
            var quit = false;

            while (!quit)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Sprawdź czy baza danych istnieje");
                Console.WriteLine("2) Wyświetl wszystkie książki znajdujące się w bazie danych");
                Console.WriteLine("3) Dodaj nową książkę do bazy danych");
                Console.WriteLine("4) Aktualizuj książkę w bazie danych");
                Console.WriteLine("5) Usuń książkę z bazy danych");
                Console.WriteLine("6) Wyszukaj po tytule");
                Console.WriteLine("7) Wyszukaj po wydawcy");
                Console.WriteLine("delete) Usuń bazę danych");
                Console.WriteLine("9) Wyświetl autora");
                Console.WriteLine("\n0) Wyjście");
                Console.Write("\nWybór:          \b\b\b\b\b\b\b\b\b");
                var opcja = Console.ReadLine();
                switch (opcja.ToLower())
                {
                    case "0":
                        quit = true;
                        break;
                    case "1":
                        await CreateTheDatabaseAsync(true);
                        WyczyscEkran();
                        break;
                    case "2":
                        await ReadBookAsync();
                        WyczyscEkran();
                        break;
                    case "3":
                        await AddBookAsync();
                        WyczyscEkran();
                        break;
                    case "4":
                        await UpdateBookAsync();
                        WyczyscEkran();
                        break;
                    case "5":
                        await DeleteBooksAsync();
                        WyczyscEkran();
                        break;
                    case "6":
                        await QueryBooks1Async();
                        WyczyscEkran();
                        break;
                    case "7":
                        await QueryBooks2Async();
                        WyczyscEkran();
                        break;
                    case "delete":
                        await DeleteDatabaseAsync();
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

        public static void WyczyscEkran()
        {
            Console.ReadLine();
            Console.SetCursorPosition(0, 6);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("                                                                                                                      ");
            }
        }

        private static void WyswietlDaneKomputera()
        {
            Console.WriteLine("Laboratorium 6, zadanie 6");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }
    }
}
