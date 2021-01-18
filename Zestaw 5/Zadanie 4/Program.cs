using System;

namespace Zadanie_4
{
    class Program
    {
        static void Main(string[] args)
        {
            WyswietlDaneKomputera();
            Program p = new Program();
            p.Subscribe();
        }
        private static void WyswietlDaneKomputera()
        {
            Console.WriteLine("Laboratorium 5, zadanie 4");
            Console.WriteLine("Karpiński Maciej, numer albumu: 39446");
            Console.WriteLine("Huawei Matebook D 15 (2018)\n");
        }
        public void Subscribe()
        {
            Zdarzenia e = new Zdarzenia();

            e.LowerCase += delegate () { Console.WriteLine("Mała litera"); };
            e.UpperCase += delegate () { Console.WriteLine("Duża litera"); };
            e.Digit += () => Console.WriteLine("Cyfra");
            e.Key += () => Console.WriteLine("Znak");
            e.FunctionKey += () => Console.WriteLine("Klawisz funkcyjny");
            e.Alt_Key += () => Console.WriteLine("Alt+klawisz");
            e.Ctrl_Key += () => Console.WriteLine("Ctrl+klawisz");
            e.Ctrl_Alt_Key += () => Console.WriteLine("Ctrl+Alt+klawisz");
            e.AnotherKey += () => Console.WriteLine("Inny");

            e.Check();
        }
    }
}
