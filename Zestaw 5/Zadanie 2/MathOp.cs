using System;

namespace Zadanie_2
{

    public class MathOp
    {
        public double Add(double x, double y) => x + y;
        public double Sub(double x, double y) => x - y;
        public double Mul(double x, double y) => x * y;

        public double Div(double x, double y)
        {
            try
            {
                return x / y;
            }
            catch (Exception e)
            {
                Console.WriteLine("Nie można dzielić przez 0!");
                throw e;
            }
        }
    }
}