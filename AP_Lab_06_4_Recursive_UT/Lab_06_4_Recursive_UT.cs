/* Lab_06_4_Recursive_UT.cs
 * Якубовський Владислав
 * Unit-test до програми Lab_06_4_Recursive.cs */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static AP_Lab_06_4_Recursive.Lab_06_4_Recursive;

namespace AP_Lab_06_4_Recursive_UT
{
    [TestClass]
    public class Lab_06_4_Recursive_UT
    {
        [TestMethod]
        public void TestSummarizeElementsWithOddIndexes()
        {
            double[] array = { -1, 0.6, 1.3, -0.6, 0.6, -0.5, 0.2 };

            double sum = SummarizeElementsWithOddIndexes(array);

            Assert.AreEqual(-0.5, sum);
        }

        [TestMethod]
        public void TestSummarizeArrayIntersection()
        {
            double[] array = { -1.1, 0.6, 1.3, -0.6, 0.6, -0.5, 0.2 };

            double sum = SummarizeArrayIntersection(array, FindFirstIndex(array), 
                FindLastIndex(array, FindFirstIndex(array),array.Length - 1), FindFirstIndex(array) + 1);

            Assert.AreEqual(1.9, sum);
        }

        [TestMethod]
        public void TestCompressArray()
        {
            double[] array = { -1.1, 0.6, 1.3, -0.6, 0.6, -0.5, 0.2 },
                expectedCompressedArray = { -1.1, 1.3, 0, 0, 0, 0 };
            int zerosCount = ZerosCount(ref array, out int zeroIndex, array.Length - 1, 0),
                compressedArraySize = array.Length - CountSmallElements(array) + zerosCount;

            double[] actualCompressedArray = new double[compressedArraySize];
            CompressArray(array, zeroIndex, actualCompressedArray);

            Assert.IsTrue(Enumerable.SequenceEqual(expectedCompressedArray, actualCompressedArray));
        }
    }
}
