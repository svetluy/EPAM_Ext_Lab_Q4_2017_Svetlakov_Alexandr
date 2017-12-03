namespace Task03
{
    using static System.Console;

    public static class Logic
    {
        public static void WriteArr(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Write($"{ arr[i, j] } "); 
                }

                WriteLine();
            }

            WriteLine();
        }

        public static int[,] CreateArr(int n, int m, int maxValue)
        {
            var arr = new int[n, m];
            var rand = new System.Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next((2 * maxValue) + 1) - maxValue;
                }
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

        public static int EvenSum(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0) 
                    {
                        sum += arr[i, j]; // even position
                    }
                }
            }

            return sum;
        }
    }
}
