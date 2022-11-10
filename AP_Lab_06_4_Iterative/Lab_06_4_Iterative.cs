/* Lab_06_4_Iterative.cs
 * Якубовський Владислав
 * Лабораторна робота № 6.4 
 * Опрацювання та впорядкування одновимірних динамічних масивів (ітераційний спосіб).
 * Варіант 24 */
using System;

namespace AP_Lab_06_4_Iterative
{
    public class Lab_06_4_Iterative
    {
        readonly static Random random = new Random();

        public static double SummarizeElementsWithOddIndexes(double[] array)
        {
            double sum = 0;

            for (int ii = 0; ii < array.Length; ii++)
                if (ii % 2 != 0) sum += array[ii];

            return sum;
        }

        public static double SummarizeArrayIntersection(double[] array, out int firstIndex, out int lastIndex)
        {
            double sum = 0;

            firstIndex = 0; lastIndex = 0;

            for (int ii = 0; ii < array.Length; ii++)
                if (array[ii] < 0)
                {
                    firstIndex = ii;
                    break;
                }

            for (int ii = array.Length - 1; ii > firstIndex; ii--)
                if (array[ii] < 0)
                {
                    lastIndex = ii;
                    break;
                }

            for (int ii = firstIndex + 1; ii < lastIndex; ii++)
            {
                sum += array[ii];
            }

            return sum;
        }

        public static double[] CompressArray(double[] array)
        {
            int zerosCount = 0, zerosStartIndex = array.Length;

            for (int ii = array.Length - 1; ii > 0; ii--)
            {
                if (Math.Abs(array[ii]) <= 1)
                {
                    array[ii] = 0;
                    zerosCount++;
                }

                else
                {
                    zerosStartIndex = ii;
                    break;
                }
            }

            int compressedArraySize = array.Length - CountSmallElements(array) + zerosCount;

            double[] compressedArray = new double[compressedArraySize];

            for (int ii = 0, jj = 0; ii < array.Length; ii++)
            {
                if (ii > zerosStartIndex)
                {
                    compressedArray[jj] = 0;

                    jj++;
                }

                else if (Math.Abs(array[ii]) > 1)
                {
                    compressedArray[jj] = array[ii];

                    jj++;
                }
            }

            return compressedArray;
        }

        static double[] GenerateArray(int size)
        {
            double[] generatedArray = new double[size];

            for (int ii = 0; ii < size; ii++)
                generatedArray[ii] = random.Next(-2, 2) + random.NextDouble();

            return generatedArray;
        }

        static void DisplayArray(double[] array)
        {
            for (int ii = 0; ii < array.Length; ii++)
                Console.Write(((ii == 0) ? "{ " : "") + $"{array[ii]:0.###}" + ((ii < array.Length - 1) ? ", " : "") + ((ii == array.Length - 1) ? " }\n" : ""));
        }

        static int CountSmallElements(double[] array)
        {
            int count = 0;

            for (int ii = 0; ii < array.Length; ii++)
                if (Math.Abs(array[ii]) <= 1) count++;

            return count;
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Console.Write("Введіть розмір масиву: ");

            int n = int.Parse(Console.ReadLine());

            double[] array = GenerateArray(n);

            Console.Write("Згенерований масив: "); DisplayArray(array);

            double firstSum = SummarizeElementsWithOddIndexes(array),
                secondSum = SummarizeArrayIntersection(array, out int firstIndex, out int lastIndex);

            Console.Write($"Сума елементів масиву з непарними номерами: {firstSum:0.###}\n" +
                $"Сума елементів масиву між першим і останнім від'ємними елементами: " + ((firstIndex == lastIndex) ? 
                "помилка, умова не виконується!" : $"{secondSum:0.###}"));

            double[] compressedArray = CompressArray(array);

            Console.Write("\nСтиснутий масив: "); DisplayArray(compressedArray);

            Console.ReadLine();
        }
    }
}
