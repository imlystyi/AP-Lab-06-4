/* Lab_06_4_Iterative_UT.cs
 * Якубовський Владислав
 * Unit-test до програми Lab_06_4_Iterative.cs */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static AP_Lab_06_4_Iterative.Lab_06_4_Iterative;

namespace AP_Lab_06_4_Iterative_UT
{
    [TestClass]
    public class Lab_06_4_Iterative_UT
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

            double sum = SummarizeArrayIntersection(array, out _, out _);

            Assert.AreEqual(1.9, sum);
        }

        [TestMethod]
        public void TestCompressArray()
        {
            double[] array = { -1.1, 0.6, 1.3, -0.6, 0.6, -0.5, 0.2 },
                expectedCompressedArray = { -1.1, 1.3, 0, 0, 0, 0 },
                actualCompressedArray = CompressArray(array);

            Assert.IsTrue(Enumerable.SequenceEqual(expectedCompressedArray, actualCompressedArray));
        }
    }
}
