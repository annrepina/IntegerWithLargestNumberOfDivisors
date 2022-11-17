namespace Services
{
    public class ServiceFunctions
    {
        /// <summary>
        /// Обобщенная функция, которая меняет значения двух переменных
        /// </summary>
        /// <typeparam name="T">Тип объектов</typeparam>
        /// <param name="x">Первая переменная</param>
        /// <param name="y">Вторая переменная</param>
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
}