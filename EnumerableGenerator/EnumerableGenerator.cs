namespace EnumerableGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public static class EnumerableGenerator
    {
        #region Public methods

        /// <summary>
        /// Generates Fibonacci sequence starting from 0 and 1 elements to number with <paramref name="numbersAmount"/> index.
        /// </summary>
        /// <param name="numbersAmount">Index of the last element in the sequence.</param>
        /// <returns>Enumeration of fibonacci numbers.</returns>
        /// <exception cref="ArgumentException"><paramref name="numbersAmount"/> is less than 1.</exception>
        public static IEnumerable<BigInteger> FibonacciSequence(long numbersAmount)
        {
            numbersAmount = numbersAmount >= 1 ? numbersAmount : 
                                                 throw new ArgumentException($"{nameof(numbersAmount)} must be greater than zero.");

            return Fibonacci(numbersAmount);
        }

        #endregion

        #region Private methods

        private static IEnumerable<BigInteger> Fibonacci(long numbersAmount)
        {
            BigInteger prePrevious = 0;
            BigInteger previous = 1;

            yield return prePrevious;

            if (numbersAmount > 1)
            {
                yield return previous;
            }

            for (long i = 2; i < numbersAmount; i++)
            {
                BigInteger current = previous + prePrevious;
                prePrevious = previous;
                previous = current;

                yield return current;
            }
        }

        #endregion
    }
}
