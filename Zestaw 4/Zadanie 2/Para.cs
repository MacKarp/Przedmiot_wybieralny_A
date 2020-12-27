using System;
using System.Diagnostics.CodeAnalysis;

namespace Zadanie_2
{
    public class Para<T> : IComparable<Para<T>> where T : IComparable<T>
    {
        private T first = default(T), second = default(T);

        public Para(T first, T second)
        {
            this.first = first;
            this.second = second;
        }

        public override string ToString()
        {
            return first.ToString() + "\t" + second.ToString();
        }

        public int CompareTo(Para<T> other)
        {
            if (this.first.Equals(other.first))
            {
                return this.second.CompareTo(other.second);
            }
            else
            {
                return this.first.CompareTo(other.first);
            }
        }
    }
}