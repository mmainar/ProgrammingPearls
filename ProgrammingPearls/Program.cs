using System;
using System.Diagnostics;

namespace ProgrammingPearls
{
    class Program
    {
        private static int _n;
        private static float[] x;
        private static Random _random;
        private static Maxsum maxSum;

        static void Main(string[] args)
        {
            _n = 10;
            _random = new Random();
            maxSum = new Maxsum();
            var sw = new Stopwatch();
        
            while (_n < 100000)
            {
                sprinkle();
                Console.WriteLine("Input size n = {0}", _n);

                long bytes = GC.GetTotalMemory(true);
                //sw.Start();
                //float result1 = maxSum.MaxSum1(x);
                //sw.Stop();
                //Console.WriteLine("1) {0}", sw.Elapsed);
            
                //sw.Restart();
                //float result2a = maxSum.MaxSum2a(x);
                //sw.Stop();
                //Console.WriteLine("2) {0}", sw.Elapsed);

                //sw.Restart();
                //float result2b = maxSum.MaxSum2b(x);
                //sw.Stop();
                //Console.WriteLine("3) {0}", sw.Elapsed);

                sw.Restart();
                float result3 = maxSum.MaxSum3(x);
                sw.Stop();
                Console.WriteLine("4) {0}", sw.Elapsed);

                sw.Restart();
                float result4 = maxSum.MaxSum4(x);
                sw.Stop();
                Console.WriteLine("5) {0}", sw.Elapsed);

                //Console.WriteLine("Results: {0} {1} {2} {3} {4}", result1, result2a, result2b, result3, result4);
                Console.WriteLine("Results: {0} {1}", result3, result4);

                _n *= 10;
            }


            Console.WriteLine("Press a key to exist");
            Console.ReadLine();
        }

        private static void sprinkle() /* Fill x[n] with reals uniform on [-1,1] */
        {
            x = new float[_n];
            int i;
            for (i = 0; i < _n; i++)
                x[i] = 1 - 2 * ((float)_random.NextDouble());
        }
    }
}
