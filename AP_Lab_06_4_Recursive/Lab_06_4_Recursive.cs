/* Lab_06_4_Recursive.cs
 * Якубовський Владислав
 * Лабораторна робота № 6.4 
 * Опрацювання та впорядкування одновимірних динамічних масивів (рекурсивний спосіб).
 * Варіант 24 */
using System;

namespace AP_Lab_06_4_Recursive
{
    public class Lab_06_4_Recursive
    {
        readonly static Random random = new Random();

        public static int CountSmallElements(double[] array, int count = 0, int ii = 0)
        {
            if (ii < array.Length)
            {
                if (Math.Abs(array[ii]) <= 1)
                    count++;

                return CountSmallElements(array, count, ++ii);
            }

            else return count;
        }

        public static double SummarizeElementsWithOddIndexes(double[] array, double sum = 0, int ii = 0)
        {
            if (ii < array.Length)
            {
                if (ii % 2 != 0)
                    sum += array[ii];

                return SummarizeElementsWithOddIndexes(array, sum, ++ii);
            }

            else return sum;
        }

        public static int FindFirstIndex(double[] array, int ii = 0)
        {
            int firstIndex = 0;

            if (ii < array.Length)
            {
                if (array[ii] < 0)
                    return ii;

                else return FindFirstIndex(array, ii + 1);
            }

            else return firstIndex;
        }

        public static int FindLastIndex(double[] array, int firstIndex, int ii)
        {
            int lastIndex = 0;

            if (ii > firstIndex)
            {
                if (array[ii] < 0)
                    return ii;

                else return FindLastIndex(array, firstIndex, --ii);
            }

            else return lastIndex;
        }

        public static double SummarizeArrayIntersection(double[] array, int firstIndex, int lastIndex, int ii, double sum = 0)
        {
            if (ii < lastIndex)
            {
                sum += array[ii];

                return SummarizeArrayIntersection(array, firstIndex, lastIndex, ++ii, sum);
            }

            else return sum;
        }

        public static int ZerosCount(ref double[] array, out int zerosStartIndex, int ii = 0, int zeroCount = 0)
        {
            zerosStartIndex = array.Length;

            if (ii > 0)
            {
                if (Math.Abs(array[ii]) <= 1)
                {
                    array[ii] = 0;

                    return ZerosCount(ref array, out zerosStartIndex, --ii, ++zeroCount);
                }

                else
                {
                    zerosStartIndex = ii;
                }
            }

            return zeroCount;
        }

        public static void CompressArray(double[] array, int zeroIndex, double[] compressedArray, int ii = 0, int jj = 0)
        {
            if (ii < array.Length)
            {
                if (ii > zeroIndex)
                {
                    compressedArray[jj] = 0;

                    jj++;
                }

                else if (Math.Abs(array[ii]) > 1)
                {
                    compressedArray[jj] = array[ii];

                    jj++;
                }

                CompressArray(array, zeroIndex, compressedArray, ++ii, jj);
            }

            return;
        }

        static void GenerateArray(ref double[] array, int ii = 0)
        {
            if (ii < array.Length)
            {
                array[ii] = random.Next(-2, 2) + random.NextDouble();

                GenerateArray(ref array, ++ii);
            }
        }

        static void DisplayArray(double[] array, int ii = 0)
        {
            if (ii < array.Length)
            {
                Console.Write(((ii == 0) ? "{ " : "") + $"{array[ii]:0.###}" + ((ii < array.Length - 1) ? ", " : "") + ((ii == array.Length - 1) ? " }\n" : ""));

                DisplayArray(array, ++ii);
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Console.Write("Введіть розмір масиву: ");

            int n = int.Parse(Console.ReadLine());

            double[] array = new double[n];

            GenerateArray(ref array);

            Console.Write("Згенерований масив: "); DisplayArray(array);

            int firstIndex = FindFirstIndex(array),
                lastIndex = FindLastIndex(array, firstIndex, n - 1),
                zerosCount = ZerosCount(ref array, out int zerosStartIndex, n - 1, 0),
                compressedArraySize = n - CountSmallElements(array) + zerosCount;

            double firstSum = SummarizeElementsWithOddIndexes(array),
                secondSum = SummarizeArrayIntersection(array, firstIndex, lastIndex, firstIndex + 1);

            Console.Write($"Сума елементів масиву з непарними номерами: {firstSum:0.###}\n" +
                    $"Сума елементів масиву між першим і останнім від'ємними елементами: " + ((firstIndex == lastIndex) ? 
                    "помилка, умова не виконується!" : $"{secondSum:0.###}"));

            double[] compressedArray = new double[compressedArraySize];

            CompressArray(array, zerosStartIndex, compressedArray);

            Console.Write("\nСтиснутий масив: "); DisplayArray(compressedArray);

            Console.ReadLine();            
        }
    }
}
