using System;

namespace Challenges
{
    internal class DigitAdder
    {
        private readonly Digit[] RAM = new Digit[9];

        public void Main()
        {
            while (true)
            {
                try
                {
                    ClearRAM();
                    Console.Write("1: ");
                    SetNumber(0, Console.ReadLine());
                    Console.Write("2: ");
                    SetNumber(3, Console.ReadLine());
                    Process();
                    Console.WriteLine($"Result: {ReadResult()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public void Test()
        {
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    ClearRAM();
                    SetNumber(0, i);
                    SetNumber(3, j);
                    Process();
                    var res = int.Parse(ReadResult());

                    var sum = (i + j) % 1000;

                    if (res == sum)
                    {
                        Console.WriteLine($"{i} + {j} = {res} .. PASSED");
                    }
                    else
                    {
                        Console.WriteLine($"{i} + {j} = {res} .. FAILED");
                        goto End;
                    }
                }
            }
            Console.WriteLine("PASSED all tests!");
        End:
            Console.Write("Press any key to exit...");
            Console.ReadKey(true);
        }

        private void ClearRAM()
        {
            for (int i = 0; i < RAM.Length; i++) RAM[i] = new Digit(0);
        }

        private void SetNumber(int startIndex, string? value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            SetNumber(startIndex, int.Parse(value));
        }

        private void SetNumber(int startIndex, int value)
        {
            var s = (value % 1000).ToString("D3");

            for (int i = 0; i < 3; i++)
            {
                RAM[startIndex + i] = Digit.Parse(s[i].ToString());
            }
        }

        private string ReadResult()
        {
            var str = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                str += RAM[6 + i].ToString();
            }

            return str;
        }

        private void Process()
        {
            //code goes here...

        }

        private struct Digit
        {
            public static Digit Carry { get; private set; } = new Digit(0);

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

                if (av > 9) Carry = new Digit(1);
                else Carry = new Digit(0);

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
}

