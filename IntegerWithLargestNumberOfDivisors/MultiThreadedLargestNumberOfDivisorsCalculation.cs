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
        public int NumberOfThreads { get; set; }

        /// <summary>
        /// Стартовые и конечные числа для тредов, когда они будут проходить по числам в диапазоне
        /// </summary>
        private int[] _startEndNumbers;

        /// <summary>
        /// Стартовые и конечные и
        /// </summary>
        private int[] _startEndIndexes;

        /// <summary>
        /// Массив потоков
        /// </summary>
        private Thread[] _threads;

        /// <summary>
        /// Объект класса, который отвечает за нахождение чисел с наибольшим количеством делителей
        /// </summary>
        public LargestNumberOfDivisorsCalculation LargestNumberOfDivisorsCalculation { get; set; }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="largestNumberOfDivisorsCalculation">Класс, который отвечает за расчеты наибольшего кол-ва делителей в однопоточном режиме</param>
        public MultiThreadedLargestNumberOfDivisorsCalculation(LargestNumberOfDivisorsCalculation largestNumberOfDivisorsCalculation)
        {
            LargestNumberOfDivisorsCalculation = new LargestNumberOfDivisorsCalculation(largestNumberOfDivisorsCalculation.StartNumberOfRange, largestNumberOfDivisorsCalculation.EndNumberOfRange);
            NumberOfThreads = 10;
            _threads = new Thread[NumberOfThreads];

            _startEndNumbers = new int[NumberOfThreads + 1];
            _startEndIndexes = new int[NumberOfThreads + 1];
        }

        /// <summary>
        /// Заполнить стартовые и конечные индексы
        /// </summary>
        /// <param name="array">Массив в который записываются данные</param>
        /// <param name="startValue">Стартовое значенияе</param>
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

        /// <summary>
        /// Посчитать максимальное кол-во делителей каждого числа в многопотоке
        /// </summary>
        private void CountAllNumbersOfDivisorsMultiThreded()
        {
            for(int i = 0; i < NumberOfThreads; i++)
            {
                int indexForAvoidingClosure = i;
                Thread thread = new Thread(() => LargestNumberOfDivisorsCalculation.CountAllNumbersOfDivisors(_startEndNumbers[indexForAvoidingClosure], _startEndNumbers[indexForAvoidingClosure + 1], _startEndIndexes[indexForAvoidingClosure], _startEndIndexes[indexForAvoidingClosure + 1]));

                _threads[i] = thread;
                _threads[i].Start();
            }

            for (int i = 0; i < NumberOfThreads; i++)
            {
                _threads[i].Join();
            }
        }

        /// <summary>
        /// Запустить многопотоковое вычисление
        /// </summary>
        public void LaunchMultiThreadedCalculation()
        {
            FillStartEndNumbersAndIndexes(_startEndNumbers, LargestNumberOfDivisorsCalculation.StartNumberOfRange);
            FillStartEndNumbersAndIndexes(_startEndIndexes, 0);

            CountAllNumbersOfDivisorsMultiThreded();

            CalculateAllNumbersWithLargestDivisorsMultiThreded();
        }

        /// <summary>
        /// Расчитать каким числам принадлежат максимальные кол-ва делителей многопоточно
        /// </summary>
        private void CalculateAllNumbersWithLargestDivisorsMultiThreded()
        {
            for (int i = 0; i < NumberOfThreads; i++)
            {
                int indexForAvoidingClosure = i;
                Thread thread = new Thread(() => LargestNumberOfDivisorsCalculation.CalculateAllNumbersWithLargestDivisors(_startEndNumbers[indexForAvoidingClosure], _startEndNumbers[indexForAvoidingClosure + 1], _startEndIndexes[indexForAvoidingClosure], _startEndIndexes[indexForAvoidingClosure + 1]));

                _threads[i] = thread;
                _threads[i].Start();
            }

            for (int i = 0; i < NumberOfThreads; i++)
            {
                _threads[i].Join();
            }
        }
    }
}