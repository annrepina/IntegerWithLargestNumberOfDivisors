using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerWithLargestNumberOfDivisors
{
    /// <summary>
    /// Класс, который отвечает за нахождение чисел с наибольшим количеством делителей
    /// </summary>
    public class LargestNumberOfDivisorsCalculation
    {
        /// <summary>
        /// Первое число диапазона
        /// </summary>
        private int _startNumberOfRange;

        /// <summary>
        /// Последнее число диапазона
        /// </summary>
        private int _endNumberOfRange;

        /// <summary>
        /// Массив делителей каждого числа из диапазона
        /// </summary>
        private int[] _divisors;

        /// <summary>
        /// Наибольшее число делителей, которое есть у какого-то из чисел
        /// </summary>
        private int _maxNumberOfDivisors;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Первое число диапазона</param>
        /// <param name="y">Второе число диапазона</param>
        public LargestNumberOfDivisorsCalculation(int x, int y)
        {
            _startNumberOfRange = x;
            _endNumberOfRange = y;
            _divisors = new int[y - x + 1];
        }

        /// <summary>
        /// Посчитать максимальное кол-во делителей числа
        /// </summary>
        /// <param name="number">Число, у которого считают максимальное число делителей</param>
        /// <returns></returns>
        private int CountMaxNumberOfDivisors(int number)
        {
            int sum = 0;

            int maxBound = (Int32)Math.Sqrt(number);

            for (int i = 0; i < maxBound; ++i)
            {
                if(number % i == 0)
                {
                    if (number / i == i)
                        ++sum;

                    else
                        sum += 2;
                }
            }

            return sum;
        }

        /// <summary>
        /// Посчитать все делители всех чисел
        /// </summary>
        private void CountAllNumbersOfDivisors()
        {
            int maxBound = _endNumberOfRange - _startNumberOfRange + 1;

            //// создаем массив для хранения всех делителей
            //int[] divisors = new int[_endNumberOfRange - _startNumberOfRange + 1];

            for (int i = _startNumberOfRange, j = 0; i <= _endNumberOfRange && j < maxBound; ++i, ++j)
            {
                int numberOfDivisors = CountMaxNumberOfDivisors(i);

                _divisors[j] = numberOfDivisors;
            }
        }

        /// <summary>
        /// Посчитать максимальное кол-во делителей среи всех количеств делителей
        /// </summary>
        /// <returns></returns>
        private int CalculateMaxNumberOfDivisors()
        {
            int max = _divisors.Max();

            return max;
        }

        /// <summary>
        /// Расчитать каким числа принадлежать максимальные кол-ва делителей
        /// </summary>
        /// <returns></returns>
        private List<int> CalculateAllNumbersWithLargestDivisors()
        {
            List<int> allNumbers = new List<int>();

            int maxBound = _endNumberOfRange - _startNumberOfRange + 1;

            for(int i = 0, j = _startNumberOfRange; i < maxBound && j <= _endNumberOfRange; ++i, ++j)
            {
                if (_divisors[i] == _maxNumberOfDivisors)
                {
                    allNumbers.Add(j);
                }
            }
            
            return allNumbers;
        }
    }
}
