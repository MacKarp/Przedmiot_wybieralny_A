using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie_1
{
    public class Test
    {
        private double a, b, c;

        public void wprowadz_dane()
        {
            Console.WriteLine("Podaj współczynniki równania kwadratowego:");
            string str;
            do
            {
                Console.Write("Podaj wartość a: ");
                str = Console.ReadLine();
            } while (!double.TryParse(str, out a));

            do
            {
                Console.Write("Podaj wartość b: ");
                str = Console.ReadLine();
            } while (!double.TryParse(str, out b));

            do
            {
                Console.Write("Podaj wartość c: ");
                str = Console.ReadLine();
            } while (!double.TryParse(str, out c));
        }

        public void oblicz_pierwastki()
        {
            if (a == 0)
            {
                Console.WriteLine("Niedozwolona wartość a!, Równanie nie jest kwadratowe!");
            }
            else
            {

                MyEquation wielomian = new MyEquation(a, b, c);
                List<double> lista_pierwiastkow = wielomian.oblicz_pierwiastki();

                if (lista_pierwiastkow.Count == 0)
                {
                    Console.WriteLine("Brak pierwiastkow!");
                }
                else if (lista_pierwiastkow.Count == 1)
                {
                    Console.WriteLine("Trójmian posiada jeden pierwiastek: x = {0}.",
                        lista_pierwiastkow.ElementAt(0));
                }
                else
                {
                    Console.WriteLine("Trójmian posiada dwa pierwiastki, x1 = {0}, x2 = {1}",
                        lista_pierwiastkow.ElementAt(0), lista_pierwiastkow.ElementAt(1));
                }
            }

        }
    }
}