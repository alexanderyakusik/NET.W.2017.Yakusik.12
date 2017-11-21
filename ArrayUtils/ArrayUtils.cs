namespace ArrayUtils
{
    using System;
    using System.Collections.Generic;

    public static class ArrayUtils
    {
        #region Public methods

        /// <summary>
        /// Searches for <paramref name="soughtElement"/> in the sorted <paramref name="array"/>
        /// using binary algorithm. 
        /// </summary>
        /// <typeparam name="T">Array elements type.</typeparam>
        /// <param name="array">Source array.</param>
        /// <param name="soughtElement">Element to be sought.</param>
        /// <param name="comparer">Object to compare array elements.</param>
        /// <returns>Index of the sought element in the array. If no such element found, returns -1.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="array"/> is not sorted in ascendant order.</exception>
        public static int BinarySearch<T>(T[] array, T soughtElement, IComparer<T> comparer)
        {
            array = array ?? throw new ArgumentNullException($"{nameof(array)} cannot be null.");
            comparer = comparer ?? Comparer<T>.Default;

            CheckSortedArray(array, comparer);

            return BinarySearchAlgorithm(array, soughtElement, comparer);
        }

        #endregion

        #region Private methods

        private static int BinarySearchAlgorithm<T>(T[] array, T soughtElement, IComparer<T> comparer)
        {
            int leftIndex = 0, rightIndex = array.Length - 1;

            if (leftIndex > rightIndex)
            {
                return -1;
            }

            while (leftIndex < rightIndex)
            {
                int currentIndex = (leftIndex + rightIndex) / 2;

                if (comparer.Compare(soughtElement, array[currentIndex]) <= 0)
                {
                    rightIndex = currentIndex;
                }
                else
                {
                    leftIndex = currentIndex + 1;
                }
            }

            if (comparer.Compare(array[rightIndex], soughtElement) == 0)
            {
                return rightIndex;
            }

            return -1;
        }

        private static void CheckSortedArray<T>(T[] array, IComparer<T> comparer)
        {
            if (array.Length == 1 || array.Length == 0)
            {
                return;
            }

            for (var i = 0; i < array.Length - 1; i++)
            {
                if (comparer.Compare(array[i], array[i + 1]) > 0)
                {
                    throw new ArgumentException($"{nameof(array)} must be sorted in ascending order.");
                }
            }
        }

        #endregion
    }
}
