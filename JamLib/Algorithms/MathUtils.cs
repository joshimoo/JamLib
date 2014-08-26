using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Algorithms
{
    // TODO: Create a  BigInteger Implementation
    public static class MathUtils
    {
        /// <summary>
        /// Clamps the input value inclusively beetwen min and max
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val">input value to clamp</param>
        /// <param name="min">maximum valid value</param>
        /// <param name="max">minimum valid value</param>
        /// <returns></returns>
        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) { return min; }
            else if (val.CompareTo(max) > 0) { return max; }
            else { return val; }
        }

        #region Factorial
        public static ulong Factorial(uint n)
        {
            ulong sum = 1;
            for (uint i = n; i > 0; i--)
            {
                // Does not work, since sum > ulong.MaxValue which results in an overflow.
                checked { sum = sum * i; }
            }

            return sum;
        }
        #endregion

        #region Fibonacci
        public static int Fib(int n) { return AdditiveSequence(n, 0, 1); }

        // Optimized since, it moves the sequences start position while decreasing the distance.
        public static int AdditiveSequence(int n, int t0, int t1)
        {
            if (n == 0) { return t0; }
            if (n == 1) { return t1; }
            return AdditiveSequence(n - 1, t1, t0 + t1);
        }
        #endregion

        #region Primes
        public enum PrimeGeneratorMethod
        {
            PrimesUptoN,        // Generates Primes upto the N-TH Prime
            PrimesSmallerThenN  // Generate all Primes smaller then N
        }
        public static List<long> PrimeGenerator(int n, PrimeGeneratorMethod generatorMethod)
        {
            var primes = new List<long>(n);
            primes.Add(2);

            // Only test the odd numbers since all others are dividable by 2.
            int counter = 1;
            for (int i = 3; counter < n; i += 2)
            {
                bool isPrime = true;
                int upperLimit = (int)Math.Sqrt(i); // Upper Limit for the Prime Index

                // Check the current Number against the prime numbers that where calculated sofar
                // If it's not prime, it can be divided by one of the prime numbers
                for (int j = 0; j < upperLimit; j++)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                // Is the current Number a Prime, then add it.
                if (isPrime) { primes.Add(i); }

                // Increment Counter based on Generator Type
                switch (generatorMethod)
                {
                    case PrimeGeneratorMethod.PrimesUptoN: counter = primes.Count; break;
                    case PrimeGeneratorMethod.PrimesSmallerThenN: counter = i; break;
                    default: throw new ArgumentOutOfRangeException("generatorMethod");
                }
            }

            // Return the Array of Prime Numbers
            return primes;
        }

        /// <summary>
        /// Factorizes a number down to there prime numbers
        /// </summary>
        /// <param name="numberToFactorize"></param>
        /// <returns></returns>
        public static int[] FactorizePrimes(int numberToFactorize)
        {
            // HACK: Add one to the number to factorize since the method returns alls Primes smaller then N, but if N is a Prime it will not return it. Therefore we add 1
            List<long> primes = PrimeGenerator(numberToFactorize + 1, PrimeGeneratorMethod.PrimesSmallerThenN);
            Stack<int> memory = new Stack<int>();


            int current = numberToFactorize;
            for (int i = 1; i < primes.Count; i++)
            {

                // If we can devide trough the current Prime Number do so.
                int prime = (int)primes[i];
                while (current % prime == 0)
                {
                    current = current / prime;
                    memory.Push(prime);
                }

                // Are we done?
                if (current == 1) { break; }
                if (prime > current) { break; } // NOTE: Make sure that we don't go into an endless loop
            }

            // HACK: Add 1 at the beginning of the Array since the Input Number must have been 1
            if (memory.Count == 0) { memory.Push(1); }

            // Return our PrimeMemory and let another Method display
            return memory.ToArray();
        }

        public static void DisplayPrimeFactorization(int numberToFactorize, int[] primeFactors)
        {
            string output = numberToFactorize + " = ";
            output += primeFactors[0];
            for (int i = 1; i < primeFactors.Length; i++)
            {
                output += " * " + primeFactors[i];
            }

            // Print it to the Console
            System.Console.WriteLine(output);
        }
        #endregion
    }
}
