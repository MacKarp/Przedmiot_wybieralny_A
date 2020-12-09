using System;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Text.Encoding;

namespace Zadanie_4
{
    class Program
    {
        static void printArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Write(arr[i] + " ");
            }
            WriteLine();
        }

        static void printArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Write($"{i,4}");
            }
            WriteLine();
        }

        static void printArray(double[] arr)
        {
            foreach (double d in arr)
            {
                Write(d + " ");
            }
            WriteLine();
        }

        static void printArray(char[] arr)
        {
            foreach (char c in arr)
            {
                Write(c + " ");
            }
            WriteLine();
        }

        static void Main(string[] args)
        {
            OutputEncoding = GetEncoding("UTF-8");

            string[] tab = { "Magda", "Jakub", "Witold", "Anna", "Tomasz", "Julia", "Jaś" };
            Write($"tab = ");
            printArray(tab);

            Array.Sort(tab);
            Write($"Array.Sort() = ");
            printArray(tab);

            WriteLine($"Array.BinarySearch(Magda) = {Array.BinarySearch(tab, "Magda")}");
            WriteLine($"Array.BinarySearch(Ula) = {Array.BinarySearch(tab, "Ula")}");

            Write($"Array.Reverse() = ");
            Array.Reverse(tab);
            printArray(tab);

            string[] tab2 = new string[tab.Length / 2];
            Array.Copy(tab, tab2, tab.Length / 2);
            Write("Array.Copy() {połowa z tab} tab2 = ");
            printArray(tab2);

            Write("Array.Clear() {zeruj 5 elementów} = ");
            Array.Clear(tab, 0, 5);
            printArray(tab);

            int[] _int = { 16, 1, 8, 2, 4 };
            Write($"\n_int = ");
            printArray(_int);

            Array.Sort(_int);
            Write($"Array.Sort() = ");
            printArray(_int);

            double[] _doubles = new double[] { 5.5, -6.2, 13.6, -8.3, -9.1 };
            Write($"\n_doubles = ");
            printArray(_doubles);

            WriteLine("Czy wszystkie elementy tablicy _doubles są większe od zera?");
            if (Array.TrueForAll(_doubles, d => d > 0))
            {
                WriteLine("Tak, wszystkie są większe od 0.");
            }
            else
            {
                WriteLine("Nie, niektóre elementy są mniejsze od 0.");
            }

            char[] _chars = new char[] { 'a', 'b', 'c', '1', '2', '3', '=', '-', ']', 's', '3', '$', '=', 'V', 'B' };
            char testChar = '=';
            Write($"\n_chars = ");
            printArray(_chars);
            WriteLine("Czy tablica _chars zawiera znak: '" + testChar + "'?");
            if (Array.Exists(_chars, c => c == testChar))
            {
                WriteLine("Tablica _chars zwiera znak: '" + testChar + "' posiada on indeks nr: " + Array.FindIndex(_chars, c => c == testChar));
                WriteLine("Ostatnie wystąpienie znaku: '" + testChar + "' posiada indeks: " + Array.LastIndexOf(_chars, testChar));
            }
            else
            {
                WriteLine("Tablica _chars nie zawiera takiego elementu");
            }
        }
    }
}
