namespace Task_03
{
    using System;
    using System.Diagnostics;

    public static class FindMethods
    {
        public static long MedianLinq(int retries, int[] test)
        {
            var sw4Arr = new long[retries];
            for (int i = 0; i < retries; i++)
            {
                var sw4 = new Stopwatch();
                sw4.Start();
                test.FindEqualLinq(5);
                sw4.Stop();
                sw4Arr[i] = sw4.ElapsedTicks;
            }

            Array.Sort(sw4Arr);
            return sw4Arr[retries / 2];
        }  // так и не понял, как метод расширения в делегат запихать 

        public static long MedianLambaDel(int retries, int[] test)
        {
            var sw3Arr = new long[retries];
            for (int i = 0; i < retries; i++)
            {
                var sw3 = new Stopwatch();
                sw3.Start();
                test.FindEqualThrouDel(5, (x, y) => x == y);
                sw3.Stop();
                sw3Arr[i] = sw3.ElapsedTicks;
            }

            Array.Sort(sw3Arr);
            return sw3Arr[retries / 2];
        }

        public static long MedianAnonDel(int retries, int[] test)
        {
            var sw2Arr = new long[retries];
            for (int i = 0; i < retries; i++)
            {
                var sw2 = new Stopwatch();
                sw2.Start();
                test.FindEqualThrouDel(5, delegate(int x, int y) { return x == y; });
                sw2.Stop();
                sw2Arr[i] = sw2.ElapsedTicks;
            }

            Array.Sort(sw2Arr);
            return sw2Arr[retries / 2];
        }

        public static long MedianDel(int retries, int[] test)
        {
            var sw1Arr = new long[retries];
            var compDel = new FindInArr.Compare(Equal);
            for (int i = 0; i < retries; i++)
            {
                var sw1 = new Stopwatch();
                sw1.Start();
                test.FindEqualThrouDel(5, compDel);
                sw1.Stop();
                sw1Arr[i] = sw1.ElapsedTicks;
            }

            Array.Sort(sw1Arr);
            return sw1Arr[retries / 2];
        }

        public static long Median(int retries, int[] test)
        {
            var arr = new long[retries];
            for (int i = 0; i < retries; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                test.FindEqual(5);
                sw.Stop();
                arr[i] = sw.ElapsedTicks;
            }

            Array.Sort(arr);
            return arr[retries / 2];
        }

        public static bool Equal(int item1, int item2)
        {
            return item1 == item2;
        }
    }
}