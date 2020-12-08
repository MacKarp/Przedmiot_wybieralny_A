using System;

namespace Zadanie_3
{
    class Program
    {
        static void Main(string[] args)
        {
            CountTypes(5, 6, 'a', -3.5, 3.5, "hej", 5.5f, -15.5f, "Maciej", "Anna");
        }

        private static void CountTypes(params object[] args)
        {
            int parzyste_int = 0;
            int dodatnie_float = 0;
            int douuble = 0;
            int string_dlugosci_5 = 0;
            int inne = 0;

            foreach (var arg in args)
            {

                switch (arg.GetType().Name)
                {
                    case "Int32":
                        int t_i = int.Parse(arg.ToString());
                        if (t_i % 2 == 0)
                        {
                            parzyste_int++;
                        }
                        break;


                    case "Single":
                        float t_f = float.Parse(arg.ToString());
                        if (t_f > 0)
                        {
                            dodatnie_float++;
                        }
                        break;

                    case "Double":
                        douuble++;
                        break;

                    case "String":
                        if (arg.ToString().Length >= 5)
                        {
                            string_dlugosci_5++;
                        }
                        break;

                    default:
                        inne++;
                        break;
                }
            }
            Console.WriteLine("Parzyste int: " + parzyste_int);
            Console.WriteLine("Dodatnie float:" + dodatnie_float);
            Console.WriteLine("Double: " + douuble);
            Console.WriteLine("Stringi o długości większej niż 5: " + string_dlugosci_5);
            Console.WriteLine("Inne typy: " + inne);
        }
    }
}
