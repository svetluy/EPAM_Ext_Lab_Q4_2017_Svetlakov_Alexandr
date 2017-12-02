namespace Task01
{
    using static System.Console;

    public static class Logic
    {
        public static void SortArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var f = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                        f = true;
                    }
                }

                if (!f)
                {
                    break;
                }
            }
        }

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
    }
}
