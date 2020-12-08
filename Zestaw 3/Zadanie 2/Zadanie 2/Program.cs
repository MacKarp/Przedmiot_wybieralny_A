using System;
using System.ComponentModel.Design;
using System.Data.Common;

namespace Zadanie_2
{
    public readonly struct Fraction
    {
        public readonly int num;
        public readonly int den;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
            }

            num = numerator;
            den = denominator;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.num * b.num, a.den * b.den);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.num == 0)
            {
                throw new DivideByZeroException();
            }

            return new Fraction(a.num * b.den, a.den * b.num);
        }

        public override string ToString() => $"{num} / {den}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = default, b = default;
            bool czy_poprawna = false;
            do
            {
                try
                {
                    Console.Write("Wprowadź ułamek a: ");
                    a = Wczytaj_Ulamek();
                    czy_poprawna = true;
                }
                catch
                {
                    Console.WriteLine("Nieprawidłowa wartość, spróbuj jeszcze raz!");
                }
            } while (!czy_poprawna);

            czy_poprawna = false;
            do
            {
                try
                {
                    Console.Write("Wprowadź ułamek b: ");
                    b = Wczytaj_Ulamek();
                    czy_poprawna = true;
                }
                catch
                {
                    Console.WriteLine("Nieprawidłowa wartość, spróbuj jeszcze raz!");
                }
            } while (!czy_poprawna);

            Wyniki(a, b);
        }

        private static Fraction Wczytaj_Ulamek()
        {
            var wczytaj = Console.ReadLine();
            string[] ulamek = wczytaj.Split('/');
            return new Fraction(int.Parse(ulamek[0]), int.Parse(ulamek[1]));
        }

        private static string Ulamek_Mieszany(Fraction a)
        {
            int cale = a.num / a.den;
            int reszta = a.num % a.den;
            string wynik = string.Empty;

            if (cale > 0)
            {
                wynik = cale.ToString();
            }

            if (reszta != 0)
            {
                wynik += " " + reszta + "/" + a.den;
            }
            return wynik;
        }

        private static int nwd(Fraction ulamek)
        {
            int num = ulamek.num;
            int den = ulamek.den;
            return (num == 0) ? den : nwd(new Fraction(den % num, num));
        }

        private static Fraction redukuj(Fraction ulamek)
        {
            int num = ulamek.num;
            int den = ulamek.den;
            int t = nwd(ulamek);
            num /= t;
            den /= t;
            return new Fraction(num, den);
        }

        private static void Wyniki(Fraction a, Fraction b)
        {
            Console.WriteLine("Wyniki: ");
            Console.WriteLine("a = " + Ulamek_Mieszany(redukuj(a)));
            Console.WriteLine("b = " + Ulamek_Mieszany(redukuj(b)));
            var c = a + b;
            Console.WriteLine("a + b = " + Ulamek_Mieszany(redukuj(c)));

            c = a - b;
            Console.WriteLine("a - b = " + Ulamek_Mieszany(redukuj(c)));

            c = a * b;
            Console.WriteLine("a * b = " + Ulamek_Mieszany(redukuj(c)));

            c = a / b;
            Console.WriteLine("a / b = " + Ulamek_Mieszany(redukuj(c)));
        }
    }
}