using System;

namespace Zadanie_5
{
    internal class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void RaiseNewCarInfo(string car)
        {
            Console.WriteLine("\nDealer, nowe auto: {0}", car);
            NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
        }
    }
}