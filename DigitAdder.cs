using System;

namespace Challenges
{
    internal class DigitAdder
    {
        private readonly Digit[] RAM = new Digit[12];

        public void Main()
        {
            while (true)
            {
                try
                {
                    Console.Write("1: ");
                    SetNumber(0, Console.ReadLine());
                    Console.Write("2: ");
                    SetNumber(4, Console.ReadLine());
                    Process();
                    Console.WriteLine($"Result: {ReadResult()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        private void SetNumber(int startIndex, string? value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            value = (int.Parse(value!) % 10000).ToString("D4");

            for (int i = 0; i < 4; i++)
            {
                RAM[startIndex + i] = Digit.Parse(value[i].ToString());
            }
        }

        private string ReadResult()
        {
            var str = string.Empty;

            for (int i = 0; i < 4; i++)
            {
                str += RAM[8 + i].ToString();
            }

            return str;
        }

        private void Process()
        {
            //code goes here...

        }
    }

    internal struct Digit
    {
        public static int Carry { get; private set; } = 0;

        private int _value;

        public Digit(int value)
        {
            _value = Math.Abs(value) % 10;
        }

        public int Value
        {
            get => _value;
            set => _value = Math.Abs(value) % 10;
        }

        public static Digit operator +(Digit a, Digit b)
        {
            var av = a.Value;
            var bv = b.Value;

            av += bv;

            if (av > 9) Carry = 1;
            else Carry = 0;

            return new Digit(av);
        }

        public static Digit operator +(Digit a, int b) => a + new Digit(b);
        public static Digit operator +(int a, Digit b) => new Digit(a) + b;

        public static bool operator ==(Digit a, Digit b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(Digit a, Digit b)
        {
            return a.Value != b.Value;
        }

        public static bool operator >(Digit a, Digit b)
        {
            return a.Value > b.Value;
        }

        public static bool operator >=(Digit a, Digit b)
        {
            return a.Value >= b.Value;
        }

        public static bool operator <(Digit a, Digit b)
        {
            return a.Value < b.Value;
        }

        public static bool operator <=(Digit a, Digit b)
        {
            return a.Value <= b.Value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public static Digit Parse(string s)
        {
            return new Digit(int.Parse(s));
        }

        public override readonly bool Equals(object? obj)
        {
            if (obj is Digit d) return d.Value == _value;
            else return false;
        }

        public override readonly int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}

