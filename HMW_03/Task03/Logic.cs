﻿namespace Task03
{
    using static System.Console;

    public static class Logic
    {
        public static void WriteArr(int[] arr)
        {
            foreach (var i in arr)
            {
                Write($"{i} ");
            }

            WriteLine();
        }

        public static int[] CreateArr(int n, int maxValue)
        {
            var arr = new int[n];
            var rand = new System.Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next((2 * maxValue) + 1) - maxValue;
            }

            return arr;
        }

        public static int InputData(string message)
        {
            int n;
            do
            {
                WriteLine(message);
                int.TryParse(ReadLine(), out n);
            }
            while (n <= 0);
            return n;
        }

        public static int SumPositive(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
