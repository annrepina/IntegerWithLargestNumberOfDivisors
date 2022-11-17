using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerWithLargestNumberOfDivisors
{
    /// <summary>
    /// Класс, который отвечает за нахождение чисел с наибольшим количеством делителей в многопоточном режиме
    /// </summary>
    public class MultiThreadedLargestNumberOfDivisorsCalculation
    {
        /// <summary>
        /// Количество потоков
        /// </summary>
        private static int NumberOfThreads;

        /// <summary>
        /// Стартовые и конечные числа для тредов, когда они будут проходить по числам в диапазоне
        /// </summary>
        private int[] _startEndNumbers;

        /// <summary>
        /// Стартовые и конечные и
        /// </summary>
        private int[] _startEndIndexes;

        ///// <summary>
        ///// Массив делителей каждого числа из диапазона
        ///// </summary>
        //private int[] _divisors;

        /// <summary>
        /// Массив потоков
        /// </summary>
        private Thread[] _threads;

        /// <summary>
        /// Объект класса, который отвечает за нахождение чисел с наибольшим количеством делителей
        /// </summary>
        public LargestNumberOfDivisorsCalculation LargestNumberOfDivisorsCalculation { get; set; }

        public MultiThreadedLargestNumberOfDivisorsCalculation(LargestNumberOfDivisorsCalculation largestNumberOfDivisorsCalculation)
        {
            LargestNumberOfDivisorsCalculation = new LargestNumberOfDivisorsCalculation(largestNumberOfDivisorsCalculation.StartNumberOfRange, largestNumberOfDivisorsCalculation.EndNumberOfRange);
            NumberOfThreads = 10;
            _startEndNumbers = new int[NumberOfThreads + 1];
            _startEndIndexes = new int[NumberOfThreads + 1];
        }

        /// <summary>
        /// Заполнить  стартовые и конечные индексы
        /// </summary>
        public void FillStartEndNumbersAndIndexes(int[] array, int startValue)
        {
            int numberOfNumbersForOneThread = (LargestNumberOfDivisorsCalculation.EndNumberOfRange - LargestNumberOfDivisorsCalculation.StartNumberOfRange + 1) / NumberOfThreads;

            int adding = numberOfNumbersForOneThread;

            if (startValue != 0)
            {
                // слагаемое
                // на 1 больше, т.к. расчеты начинаются с 1, а не с 0
                ++adding;
            }

            int max = NumberOfThreads + 1;

            // первый стартовый индекс равен первому числу в диапазоне
            array[0] = startValue;

            // начинаем с 1 т.к. первый элемент уже равен единице
            for (int i = 1; i < max; i++)
            {
                array[i] = adding;

                adding += numberOfNumbersForOneThread;
            }
        }

        public int CountAllNumbersOfDivisorsMultiThreded()
        {
            for(int i = 0; i < NumberOfThreads; i++)
            {
                int indexForAvoidingClosure = i;
                Thread thread = new Thread(() => LargestNumberOfDivisorsCalculation.CountAllNumbersOfDivisors(_startEndNumbers[indexForAvoidingClosure], _startEndNumbers[indexForAvoidingClosure + 1], _startEndIndexes[indexForAvoidingClosure], _startEndIndexes[indexForAvoidingClosure + 1])); 
            }
        }

        public void LaunchMultiThreadedCalculation()
        {
            FillStartEndNumbersAndIndexes(_startEndNumbers, LargestNumberOfDivisorsCalculation.StartNumberOfRange);
            FillStartEndNumbersAndIndexes(_startEndIndexes, 0);
        }
    }
}
