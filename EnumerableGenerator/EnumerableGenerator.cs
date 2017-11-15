namespace EnumerableGenerator
{
    using System;
    using System.Collections.Generic;

    public static class EnumerableGenerator
    {
        #region Public methods

        /// <summary>
        /// Generates Fibonacci sequence starting from 0 and 1 elements to number with <paramref name="numbersAmount"/> index.
        /// </summary>
        /// <param name="numbersAmount">Index of the last element in the sequence.</param>
        /// <returns>Enumeration of fibonacci numbers.</returns>
        /// <exception cref="ArgumentException"><paramref name="numbersAmount"/> is less than 1.</exception>
        public static IEnumerable<int> FibonacciSequence(int numbersAmount)
        {
            numbersAmount = numbersAmount >= 1 ? numbersAmount : 
                                                 throw new ArgumentException($"{nameof(numbersAmount)} must be greater than zero."); 

            int prePrevious = 0;
            int previous = 1;

            yield return prePrevious;

            if (numbersAmount > 1)
            {
                yield return previous;
            }

            for (int i = 2; i < numbersAmount; i++)
            {
                int current = previous + prePrevious;
                prePrevious = previous;
                previous = current;

                yield return current;
            }
        }

        #endregion
    }
}
