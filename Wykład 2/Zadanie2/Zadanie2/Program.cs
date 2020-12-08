using System;
using System.Globalization;
using static System.Console;
using static System.Text.Encoding;

namespace Zadanie2
{
    class Program
    {
        static String ReadName()
        {
            var result = "Witaj ";
            var name = String.Empty;
            Write("Podaj imię: ");
            name = ReadLine();
            //var len = name.Length;
            if (name.Length != 0) return result + name + "!";
            else return result + "bezimienny!";

        }

        static void Main(string[] args)
        {
            OutputEncoding = GetEncoding("UTF-8");
            WriteLine("Witaj Świecie!");
            WriteLine(ReadName() + "\n");

            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            String[] cultureNames = { "pl-PL", "en-US", "en-GB", "pt-PT", "de-AT", "ru-RU" };
            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                //WriteLine("{0}:", culture.NativeName);
                //WriteLine("\t Local date and time: {0}, {1:G}", localDate.ToString(culture), localDate.Kind);
                //WriteLine("\t UTC date and time: {0}, {1:G}\n", utcDate.ToString(culture), utcDate.Kind);
                WriteLine($"{ culture.NativeName }");
                WriteLine($"\t Local date and time:\t{localDate.ToString(culture)}, {localDate.Kind:G}");
                WriteLine($"\t UTC date and time:\t{utcDate.ToString(culture)}, {utcDate.Kind:G}");
            }
            In.Read();
        }
    }
}