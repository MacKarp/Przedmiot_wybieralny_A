using System;
using System.Collections.Generic;

namespace Zadanie_1
{
    public class MyEquation
    {
        private double _a, _b, _c;

        public MyEquation(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public List<double> oblicz_pierwiastki()
        {
            double delta = (_b * _b) - 4 * _a * _c;
            List<double> lista_pierwiastkow = new List<double>();
            if (delta < 0)
            {
                return lista_pierwiastkow;
            }
            else if (delta == 0)
            {
                double x1 = Math.Round((-_b / (2 * _a)), 3);
                lista_pierwiastkow.Add(x1);
            }
            else
            {
                double x1 = Math.Round((-_b - Math.Sqrt(delta)) / (2 * _a), 3);
                double x2 = Math.Round((-_b + Math.Sqrt(delta)) / (2 * _a), 3);

                lista_pierwiastkow.Add(x1);
                lista_pierwiastkow.Add(x2);
            }
            return lista_pierwiastkow;
        }
    }
}
