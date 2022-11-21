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
        /// <summary>
        /// Класс, который делает расчеты по поиску наибольшего кол-ва делителей в одном потоке
        /// </summary>
        private LargestNumberOfDivisorsCalculation _largestNumberOfDivisorsCalculation;

        /// <summary>
        /// Класс, который делает расчеты по поиску наибольшего кол-ва делителей в многопотоке
        /// </summary>
        private MultiThreadedLargestNumberOfDivisorsCalculation _multiThreadedLargestNumberOfDivisorsCalculation;

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

            LaunchCalculationWithStopwatch();

            PrintSingleThreadResults();

            _stopwatch.Reset();

            LaunchMultiThreadedCalculationWithStopwatch();

            PrintMultiThreadResults();

            _stopwatch.Reset();
        }

        /// <summary>
        /// Получить у пользователя число
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Напечатать имя и инструкции к программе
        /// </summary>
        private void PrintNameAndInstructions()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, 0);

            Console.WriteLine("Поиск чисел в диапазоне с наибольшим количеством делителей");

            Console.WriteLine("Введите числа: начало и конец диапазона");
        }

        /// <summary>
        /// Проверить числа
        /// </summary>
        /// <param name="x">Первое число в диапазоне</param>
        /// <param name="y">Второе число в диапазоне</param>
        private void CheckNumbers(ref int x, ref int y)
        {
            if(x > y)
                ServiceFunctions.Swap<int>(ref x, ref y);
        }

        /// <summary>
        /// Напечать результаты вычислений работы в одном потоке
        /// </summary>
        private void PrintSingleThreadResults()
        {
            Console.WriteLine("Вычисления выполненные в одном потоке, имеют такие результаты: ");
            Console.WriteLine($"Наибольшее число делителей среди чисел в диапазоне от {_largestNumberOfDivisorsCalculation.StartNumberOfRange} до {_largestNumberOfDivisorsCalculation.EndNumberOfRange} равно {_largestNumberOfDivisorsCalculation.MaxNumberOfDivisors}");
            Console.WriteLine($"Числа, которые имеют наибольшее количество делителей:");

            int maxBound = _largestNumberOfDivisorsCalculation.NumbersWithLargestDivisors.Count;

            for (int i = 0; i < maxBound; i++)
            {
                Console.Write($"{_largestNumberOfDivisorsCalculation.NumbersWithLargestDivisors[i]}\t");
            }

            Console.WriteLine($"Времы, за которое были выполнены вычисления равно: {_stopwatch.ElapsedMilliseconds} милисекунд") ;
        }

        /// <summary>
        /// Напечатать результаты вычислений работы в многопотоке
        /// </summary>
        private void PrintMultiThreadResults()
        {
            Console.WriteLine($"Вычисления выполненные в {_multiThreadedLargestNumberOfDivisorsCalculation.NumberOfThreads} потоках, имеют такие результаты: ") ;
            Console.WriteLine($"Наибольшее число делителей среди чисел в диапазоне от {_largestNumberOfDivisorsCalculation.StartNumberOfRange} до {_largestNumberOfDivisorsCalculation.EndNumberOfRange} равно {_largestNumberOfDivisorsCalculation.MaxNumberOfDivisors}");
            Console.WriteLine($"Числа, которые имеют наибольшее количество делителей:");

            int maxBound = _largestNumberOfDivisorsCalculation.NumbersWithLargestDivisors.Count;

            for (int i = 0; i < maxBound; i++)
            {
                Console.Write($"{_largestNumberOfDivisorsCalculation.NumbersWithLargestDivisors[i]}\t");
            }

            Console.WriteLine($"\nВремя, за которое были выполнены вычисления равно: {_stopwatch.ElapsedMilliseconds} милисекунд");
        }

        /// <summary>
        /// Инициализация калькуляторов для расчетов
        /// </summary>
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

            _multiThreadedLargestNumberOfDivisorsCalculation = new MultiThreadedLargestNumberOfDivisorsCalculation(_largestNumberOfDivisorsCalculation);
        }

        /// <summary>
        /// Запустить расчеты в одном потоке с секундомером
        /// </summary>
        private void LaunchCalculationWithStopwatch()
        {
            _stopwatch.Start();

            _largestNumberOfDivisorsCalculation.LaunchCalculation();

            _stopwatch?.Stop();
        }

        /// <summary>
        /// Запустить расчеты в многопотоке с секундомером
        /// </summary>
        private void LaunchMultiThreadedCalculationWithStopwatch()
        {
            _stopwatch.Start();

            _multiThreadedLargestNumberOfDivisorsCalculation.LaunchMultiThreadedCalculation();

            _stopwatch?.Stop();
        }
    }
}
