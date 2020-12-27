namespace Zadanie_3
{
    public class PairIntString : IPair<int, string>
    {
        public int First { get; set; }
        public string Second { get; set; }

        public PairIntString(int first, string second)
        {
            First = first;
            Second = second;
        }

        public void Set(int first, string second)
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