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
        /// Массив делителей каждого числа из диапазона
        /// </summary>
        private int[] _divisors;

        /// <summary>
        /// Первое число диапазона
        /// </summary>
        public int StartNumberOfRange { get; set; }

        /// <summary>
        /// Последнее число диапазона
        /// </summary>
        public int EndNumberOfRange { get; set; }

        /// <summary>
        /// Наибольшее число делителей, которое есть у какого-то из чисел
        /// </summary>
        public int MaxNumberOfDivisors { get; set; }

        public List<int> NumbersWithLargestDivisors { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Первое число диапазона</param>
        /// <param name="y">Второе число диапазона</param>
        public LargestNumberOfDivisorsCalculation(int x, int y)
        {
            StartNumberOfRange = x;
            EndNumberOfRange = y;
            _divisors = new int[y - x + 1];
            MaxNumberOfDivisors = 0;
            NumbersWithLargestDivisors = new List<int>();
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

            for (int i = 1; i < maxBound; ++i)
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
        public void CountAllNumbersOfDivisors(int startNumber, int endNumber, int startIndex, int endIndex)
        {
            //int maxBound = EndNumberOfRange - StartNumberOfRange + 1;

            //// создаем массив для хранения всех делителей
            //int[] divisors = new int[_endNumberOfRange - _startNumberOfRange + 1];

            //int max = EndNumberOfRange + 1;

            for (int i = startNumber, j = startIndex; i < endNumber && j < endIndex; ++i, ++j)
            {
                int numberOfDivisors = CountMaxNumberOfDivisors(i);

                _divisors[j] = numberOfDivisors;
            }
        }


        //private void CountAllNumbersOfDivisors()
        //{
        //    int maxBound = EndNumberOfRange - StartNumberOfRange + 1;

        //    //// создаем массив для хранения всех делителей
        //    //int[] divisors = new int[_endNumberOfRange - _startNumberOfRange + 1];

        //    int max = EndNumberOfRange + 1;

        //    for (int i = StartNumberOfRange, j = 0; i < max && j < maxBound; ++i, ++j)
        //    {
        //        int numberOfDivisors = CountMaxNumberOfDivisors(i);

        //        _divisors[j] = numberOfDivisors;
        //    }
        //}



        /// <summary>
        /// Посчитать максимальное кол-во делителей среи всех количеств делителей
        /// </summary>
        /// <returns></returns>
        private void CalculateMaxNumberOfDivisors()
        {
            MaxNumberOfDivisors = _divisors.Max();
        }

        /// <summary>
        /// Расчитать каким числа принадлежать максимальные кол-ва делителей
        /// </summary>
        /// <returns></returns>
        private void CalculateAllNumbersWithLargestDivisors()
        {
            int maxBound = EndNumberOfRange - StartNumberOfRange + 1;

            for(int i = 0, j = StartNumberOfRange; i < maxBound && j <= EndNumberOfRange; ++i, ++j)
            {
                if (_divisors[i] == MaxNumberOfDivisors)
                {
                    NumbersWithLargestDivisors.Add(j);
                }
            }
        }

        /// <summary>
        /// Запустить расчет
        /// </summary>
        public void LaunchCalculation()
        {
            CountAllNumbersOfDivisors(StartNumberOfRange, EndNumberOfRange + 1, 0, EndNumberOfRange - StartNumberOfRange + 1);

            CalculateMaxNumberOfDivisors();

            CalculateAllNumbersWithLargestDivisors();
        }

        public void AddNumberOfDivisors(int index, int number)
        {
            if(index < _divisors.Length && number >= 1)
            {
                _divisors[index] = number;
            }
        }

        ///// <summary>
        ///// Возвращает копию текущего объекта
        ///// </summary>
        ///// <returns></returns>
        //public object Clone()
        //{
        //    object clone = new LargestNumberOfDivisorsCalculation(StartNumberOfRange, EndNumberOfRange);

        //    return clone;

        //}
    }
}
