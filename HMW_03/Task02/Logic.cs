namespace Task02
{
    using static System.Console;

    public static class Logic
    {
        public static void WriteArr(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        Write($"{arr[i, j, k]} ");
                    }

                    WriteLine();
                }

                WriteLine();
            }
        }

        public static void ReplacePositive(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        public static int[,,] CreateArr(int n, int maxValue)
        {
            var arr = new int[n, n, n];
            var rand = new System.Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = rand.Next((maxValue * 2) + 1) - maxValue;
                    }
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
    } 
}