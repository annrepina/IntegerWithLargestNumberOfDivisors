using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace IntegerWithLargestNumberOfDivisors
{
    /// <summary>
    /// Приложение, которое запускает поиск чисел в диапазоне с максимальным количеством делителей
    /// </summary>
    public class NumberOfDivisorsCalculationApplication
    {
        private LargestNumberOfDivisorsCalculation _largestNumberOfDivisorsCalculation;

        /// <summary>
        /// Секундомер
        /// </summary>
        private Stopwatch _stopwatch;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public NumberOfDivisorsCalculationApplication()
        {
            _stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Запустить приложение
        /// </summary>
        public void Launch()
        {
            PrintNameAndInstructions();

            InitializeCalculatorForDivisors();

            _stopwatch.Start();

            _largestNumberOfDivisorsCalculation.LaunchCalculation();

            PrintResults();

            _stopwatch?.Stop();

            Console.WriteLine($"Время потраченное на вычисления равно {_stopwatch.ElapsedMilliseconds} милисекунд");
        }

        private int GetNumber()
        {
            Console.Write("Введите целое положительное число: ");

            bool isInt32 = Int32.TryParse(Console.ReadLine(), out int number);

            while (!isInt32 || number < 1)
            {
                Console.Write("Вы ввели недопустимое значение, попробуйте снова: ");

                isInt32 = Int32.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        private void PrintNameAndInstructions()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, 0);

            Console.WriteLine("Поиск чисел в диапазоне с наибольшим количеством делителей");

            Console.WriteLine("Введите числа: начало и конец диапазона");
        }

        private void CheckNumbers(ref int x, ref int y)
        {
            if(x > y)
                ServiceFunctions.Swap<int>(ref x, ref y);
        }

        private void PrintResults()
        {
            Console.WriteLine($"Наибольшее число делителей среди чисел в диапазоне от {_largestNumberOfDivisorsCalculation.StartNumberOfRange} до {_largestNumberOfDivisorsCalculation.EndNumberOfRange} равно {_largestNumberOfDivisorsCalculation.MaxNumberOfDivisors}");
            Console.WriteLine($"Числа, которые имеют наибольшее количество делителей:");

            int maxBound = _largestNumberOfDivisorsCalculation.NumbersWithLargestDivisors.Count;

            for (int i = 0; i < maxBound; i++)
            {
                Console.Write($"{_largestNumberOfDivisorsCalculation.NumbersWithLargestDivisors[i]}\t");
            }
        }

        private void InitializeCalculatorForDivisors()
        {
            int startNumber = GetNumber();

            int endNumber = GetNumber();

            while (startNumber == endNumber)
            {
                Console.Write("Вы ввели одинаковые значения. Введите значение конца диапазона еще раз: ");

                endNumber = GetNumber();
            }

            CheckNumbers(ref startNumber, ref startNumber);

            _largestNumberOfDivisorsCalculation = new LargestNumberOfDivisorsCalculation(startNumber, endNumber);
        }
    }
}
