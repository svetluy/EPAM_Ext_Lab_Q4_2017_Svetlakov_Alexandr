// Элемент двумерного массива считается стоящим на чётной позиции,
// если сумма номеров его позиций по обеим размерностям является
// чётным числом(например, [1,1] – чётная позиция, а[1, 2] - нет).
// Определить сумму элементов массива, стоящих на чётных позициях.

namespace Task03
{
    using static System.Console;
    using static Logic;

    internal class Program
    {
        public static void Main(string[] args)
        {
            System.ConsoleKeyInfo key;
            do
            {
                var arr = CreateArr(
                                    InputData("Input number of rows, n > 0 "), 
                                    InputData("Input number of columns, n > 0 "),
                                    InputData("Input max possible value in array, value > 0 "));

                WriteLine("Array");
                WriteArr(arr);

                WriteLine($"The sum of elements on even positions is {EvenSum(arr)}\n");

                WriteLine("Would you like to continue?\n y - Yes\n else - No");

                key = ReadKey();

                WriteLine();
            }
            while (key.Key == System.ConsoleKey.Y);
        }
    }
}
