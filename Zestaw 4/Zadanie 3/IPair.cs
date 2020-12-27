namespace Zadanie_3
{
    public interface IPair<T, S>
    {
        public T First { get; set; }
        public S Second { get; set; }
        public void Set(T first, S second);
    }
}