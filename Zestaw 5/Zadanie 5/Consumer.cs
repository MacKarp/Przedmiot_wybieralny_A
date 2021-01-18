using System;

namespace Zadanie_5
{
    internal class Consumer
    {
        private string name;

        public Consumer(string name)
        {
            this.name = name;
        }

        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine("\tInfo dla {0}; jest nowe auto: {1}", name, e.Car);
        }

        public override string ToString()
        {
            return name;
        }
    }
}