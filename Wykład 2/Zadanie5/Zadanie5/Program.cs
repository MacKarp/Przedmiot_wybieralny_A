using System;
using System.IO;

namespace Zadanie5
{
    class Program
    {
        static int count;
        static StreamReader sr;
        
        static void Main(string[] args)
        {
            String name = String.Empty;
            if (args.Length==0)
            {
                Console.Write("Podaj ścieżkę i nazwę pliku: ");
                name = Console.ReadLine();
            }
            else
            {
                name = args[0];
            }
           
            count = 0;
            try
            {
                sr = new StreamReader(name);
                ReadLines();
                sr.Close();
                Console.WriteLine($"\nLiczba linii: {count}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Komunikat systemowy: " + e.Message + "\n");
            }

            static void ReadLines()
            {
                String textLine = sr.ReadLine();
                if (textLine != null)
                {
                    Console.WriteLine(textLine);
                    count++;
                    ReadLines();
                }
            }
        }
    }
}
