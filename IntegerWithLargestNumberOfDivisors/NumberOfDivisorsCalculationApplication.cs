using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerWithLargestNumberOfDivisors
{
    /// <summary>
    /// Приложение, которое запускает поиск чисел в диапазоне с максимальным количеством делителей
    /// </summary>
    public class NumberOfDivisorsCalculationApplication
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public NumberOfDivisorsCalculationApplication()
        {

        }

        /// <summary>
        /// Запустить приложение
        /// </summary>
        public void Launch()
        {
            PrintNameAndInstructions();

            //int startNumber
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
    }
}
