namespace ArrayUtils.UnitTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    internal class ArrayUtilsTests
    {
        [Test, TestCaseSource(typeof(ArrayUtilsTestsData), nameof(ArrayUtilsTestsData.BinarySearchUnsortedArrayTestCases))]
        public void BinarySearch_UnsortedArrayPassed_ArgumentExceptionThrown<T>(T[] array, T soughtElement, IComparer<T> comparer)
        {
            Assert.Throws<ArgumentException>(() => ArrayUtils.BinarySearch(array, soughtElement, comparer));
        }

        [Test, TestCaseSource(typeof(ArrayUtilsTestsData), nameof(ArrayUtilsTestsData.BinarySearchTestCases))]
        public int BinarySearch_CorrectArrayPassed_SearchesCorrectly<T>(T[] sourceArray, T soughtElement, IComparer<T> comparer)
        {
            return ArrayUtils.BinarySearch(sourceArray, soughtElement, comparer);
        }

        [TestCase(null, 1, null)]
        public void BinarySearch_NullSourceArrayPassed_ArgumentNullExceptionThrown<T>(T[] sourceArray, T soughtElement, IComparer<T> comparer)
        {
            Assert.Throws<ArgumentNullException>(() => ArrayUtils.BinarySearch(sourceArray, soughtElement, comparer));
        }

        [Test, TestCaseSource(typeof(ArrayUtilsTestsData), nameof(ArrayUtilsTestsData.BinarySearchNullArrayTestCases))]
        public void BinarySearch_NullComparerPassed_ArgumentNullExceptionThrown<T>(T[] sourceArray, T soughtElement, IComparer<T> comparer)
        {
            Assert.Throws<ArgumentNullException>(() => ArrayUtils.BinarySearch(sourceArray, soughtElement, comparer));
        }

        private class ArrayUtilsTestsData
        {
            public static IEnumerable BinarySearchTestCases
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { -100, 23, 6, 77, 193440, 29302934 },
                        -100,
                        Comparer<int>.Default)
                        .Returns(0);
                    yield return new TestCaseData(
                        new[] { -100, 23, 6, 77, 193440, 29302934 },
                        29302934,
                        Comparer<int>.Default)
                        .Returns(5);
                    yield return new TestCaseData(
                        new[] { -100, 23, 6, 77, 193440, 29302934 },
                        77,
                        Comparer<int>.Default)
                        .Returns(3);
                    yield return new TestCaseData(
                        new[] { -100, 23, 6, 77, 193440, 29302934 },
                        5,
                        Comparer<int>.Default)
                        .Returns(-1);
                    yield return new TestCaseData(
                        new[] { 0, 2, 4, 6, 8, 10, 1500000 },
                        6,
                        Comparer<int>.Default)
                        .Returns(3);
                    yield return new TestCaseData(
                        new[] { 0, 2, 4, 6, 8, 10, 1500000 },
                        1500000,
                        Comparer<int>.Default)
                        .Returns(6);
                    yield return new TestCaseData(
                        new[] { 0, 2, 4, 6, 8, 10, 1500000 },
                        1500001,
                        Comparer<int>.Default)
                        .Returns(-1);
                }
            }

            public static IEnumerable BinarySearchUnsortedArrayTestCases
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { 3, 2, 1 },
                        -2,
                        Comparer<int>.Default);
                    yield return new TestCaseData(
                        new[] { -100, -100, -100, -100, -100, -100, -101 },
                        -2,
                        Comparer<int>.Default);
                }
            }

            public static IEnumerable BinarySearchNullArrayTestCases
            {
                get
                {
                    yield return new TestCaseData(
                        null,
                        1,
                        Comparer<int>.Default);
                }
            }
        }
    }
}
