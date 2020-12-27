namespace Zadanie_3
{
    public class GenPair<T, S> : IPair<T, S>
    {
        public T First { get; set; }
        public S Second { get; set; }

        public GenPair(T first, S second)
        {
            First = first;
            Second = second;
        }

        public void Set(T first, S second)
        {
            First = first;
            Second = second;
        }

        public override string ToString()
        {
            return $"({First},{Second})";
        }
    }
}