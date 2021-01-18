using System;

namespace Zadanie_4
{
    public class Zdarzenia
    {
        public delegate void WhichKey();

        public event WhichKey LowerCase;
        public event WhichKey UpperCase;
        public event WhichKey Digit;
        public event WhichKey Key;
        public event WhichKey FunctionKey;
        public event WhichKey Alt_Key;
        public event WhichKey Ctrl_Key;
        public event WhichKey Ctrl_Alt_Key;
        public event WhichKey AnotherKey;

        public void Check()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (!key.Key.Equals(ConsoleKey.Escape))
            {
                if ((key.Modifiers & ConsoleModifiers.Alt) != 0 || (key.Modifiers & ConsoleModifiers.Control) != 0)
                {
                    if ((key.Modifiers & ConsoleModifiers.Alt) != 0 && (key.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        Ctrl_Alt_Key();
                    }
                    else if ((key.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        Alt_Key();
                    }
                    else
                    {
                        Ctrl_Key();
                    }
                }
                else if (char.IsLower(key.KeyChar)) LowerCase();
                else if (char.IsUpper(key.KeyChar)) UpperCase();
                else if (char.IsDigit(key.KeyChar)) Digit();
                else if (char.IsPunctuation(key.KeyChar)) Key();
                else if (char.IsControl(key.KeyChar)) FunctionKey();
                else
                {
                    AnotherKey();
                }
                key = Console.ReadKey(true);
            }
        }
    }
}