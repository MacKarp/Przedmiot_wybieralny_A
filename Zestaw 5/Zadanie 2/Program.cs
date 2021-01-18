using System;
using System.Text;

namespace Zadanie_2
{
    class Program
    {


        static void ProcessAndDisplay(Func<double, double, double> myaction, double value1, double value2)
        {
            double result = myaction(value1, value2);
            Console.WriteLine($"argument 1: {value1}; argument 2: {value2}; wynik operacji: {result}");
        }

        static void Main(string[] args)
        {
            var OutputEncoding = Encoding.GetEncoding("UTF-8");
            Menu();
        }

        private static void Menu()
        {
            MathOp mo = new MathOp();
            double x = 0.0;
            double y = 0.0;
            Func<double, double, double>[] operations =
            {
                mo.Add,
                mo.Sub,
                mo.Mul,
                mo.Div,
            };
            var quit = false;
            while (!quit)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Menu:");
                Console.WriteLine("Parametry: x=" + x + "; y=" + y);
                Console.WriteLine("1) Wprowadź parametr x");
                Console.WriteLine("2) Wprowadź parametr y");
                Console.WriteLine("3) Wyświetl wyniki operacji");
                Console.WriteLine("4) Wyświetl autora");
                Console.WriteLine("\n0) Wyjście");
                Console.Write("\nWybór:          \b\b\b\b\b\b\b\b\b");
                var opcja = Console.ReadLine();
                switch (opcja)
                {
                    case "0":
                        quit = true;
                        break;
                    case "1":
                        var xOk = false;
                        while (!xOk)
                        {
                            Console.Write("Podaj parametr x: ");
                            try
                            {
                                x = double.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Nieprawidłowa wartość\n");
                            }
                            xOk = true;
                        }

                        WyczyscEkran();
                        break;
                    case "2":
                        var yOk = false;
                        while (!yOk)
                        {
                            Console.Write("Podaj parametr y: ");
                            try
                            {
                                y = double.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Nieprawidłowa wartość\n");
                            }
                            yOk = true;
                        }
                        WyczyscEkran();
                        break;
                    case "3":
                        for (int i = 0; i < operations.Length; i++)
                        {
                            Console.WriteLine($"Wywołanie 'operations[{i}]:");
                            ProcessAndDisplay(operations[i], x, y);
                            Console.WriteLine();
                        }
                        WyczyscEkran();
                        break;
                    case "4":
                        WyswietlDaneKomputera();
                        WyczyscEkran();
                        break;
                    default:
                        break;
                }

            }
        }
        public static void WyswietlDaneKomputera()
        {
            Console.WriteLine("Laboratorium 5, zadanie 2");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
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

