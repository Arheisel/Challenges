using Challenges.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Challenges
{
    internal class Ch_2 : LooperBase
    {
        private readonly Random _random = new();
        private readonly int[] Array = new int[10000];

        public void Main()
        {
            for (int i = 0; i < Array.Length; i++) Array[i] = _random.Next();

            Console.Write("SORTING .. ");

            var sw = new Stopwatch();

            sw.Start();
            Run();
            sw.Stop();

            if (Array.SequenceEqual(Array.OrderBy(x => x))) Console.WriteLine("PASSED");
            else Console.WriteLine("FAILED");

            Console.WriteLine($"Loop ended after {sw.Elapsed.TotalMilliseconds:N3}ms ({sw.ElapsedTicks:E3} ticks)");
        }

        public void Test()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Test Nº {i} .. ");
                Main();
            }
        }

        public override void Setup()
        {
            //initialization goes here...

        }

        int i = 0;

        public override void Loop()
        {
            Console.WriteLine(Array[i]);
            i++;

            if (i == Array.Length - 1) Stop(); 
        }
    }
}
