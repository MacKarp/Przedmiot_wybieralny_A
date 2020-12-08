using System;
using static System.Console;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            WriteLine("Aplikacja Kalkulator");
            Write("a: ");
            try
            {
                a = Int32.Parse(ReadLine());
                Write("b: ");
                b = Int32.Parse(ReadLine());

                Kalk k = new Kalk();
                WriteLine($"\n{a} + {b} = {k.Add(a, b)}");
                WriteLine($"\n{a} - {b} = {k.Sub(a, b)}");
                WriteLine($"\n{a} * {b} = {k.Mul(a, b)}");
                WriteLine($"\n{a} / {b} = {k.Div(a, b)}");
                WriteLine($"\n{a} % {b} = {k.Rem(a, b)}");
                WriteLine($"\n{a} ^ {b} = {k.Pow(a, b)}");
            }
            catch (OverflowException oe)
            {
                Error.WriteLine("Arytmetyczny nadmiar!\n" + oe.StackTrace + "\n");
            }
            catch (FormatException fe)
            {
                Error.WriteLine("Niepoprawny format" + fe.StackTrace + "\n");
            }
            catch (Exception e)
            {
                Error.WriteLine("Nieoczekiwany wyjątek\n" + e.ToString());
            }
        }
        internal class Kalk
        {
            public int Add(int x, int y) => x + y;
            public int Sub(int x, int y) => x - y;
            public int Mul(int x, int y) => x * y;
            public int Div(int x, int y) => x / y;
            public int Rem(int x, int y) => x % y;
            public int Pow(int x, int y)
            {
                int tmp = 1;
                while (y != 0)
                {
                    tmp *= x;
                    y--;
                }
                return tmp;
            }
        }
    }
}
