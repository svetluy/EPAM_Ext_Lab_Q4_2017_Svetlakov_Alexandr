#region Описание
// Если выписать все натуральные числа меньше 10, кратные 3, или 5, то получим 3, 5, 6 и 9. 
// Сумма этих чисел будет равна 23. 
// Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5.
#endregion
namespace Task_05
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)//todo pn частное решение
        {
            WriteLine($"Sum = {Sum(3, 5, 1000)}");
            ReadKey();
        }
        /// <summary>
        /// Cчитает сумму всех чисел меньше n, кратных a, или b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int Sum(int a, int b,int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % a == 0 || i % b == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
