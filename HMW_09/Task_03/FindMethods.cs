using System;
using System.Diagnostics;

namespace Task_03
{
    public static class FindMethods
    {
        public static long MedianLinq(int Retries, int[] test)
        {
            var sw4Arr = new long[Retries];
            for (int i = 0; i < Retries; i++)
            {
                var sw4 = new Stopwatch();
                sw4.Start();
                test.FindEqualLinq(5);
                sw4.Stop();
                sw4Arr[i] = sw4.ElapsedTicks;
            }
            Array.Sort(sw4Arr);
            return sw4Arr[Retries / 2];
        }// так и не понял, как метод расширения в делегат запихать 

        public static long MedianLambaDel(int Retries, int[] test)
        {
            var sw3Arr = new long[Retries];
            for (int i = 0; i < Retries; i++)
            {
                var sw3 = new Stopwatch();
                sw3.Start();
                test.FindEqualThrouDel(5, (x, y) => x == y);
                sw3.Stop();
                sw3Arr[i] = sw3.ElapsedTicks;
            }
            Array.Sort(sw3Arr);
            return sw3Arr[Retries / 2];
        }

        public static long MedianAnonDel(int Retries, int[] test)
        {
            var sw2Arr = new long[Retries];
            for (int i = 0; i < Retries; i++)
            {
                var sw2 = new Stopwatch();
                sw2.Start();
                test.FindEqualThrouDel(5, delegate (int x, int y) { return x == y; });
                sw2.Stop();
                sw2Arr[i] = sw2.ElapsedTicks;
            }
            Array.Sort(sw2Arr);
            return sw2Arr[Retries / 2];
        }

        public static long MedianDel(int Retries, int[] test)
        {
            var sw1Arr = new long[Retries];
            var compDel = new FindInArr.Compare(Equal);
            for (int i = 0; i < Retries; i++)
            {
                var sw1 = new Stopwatch();
                sw1.Start();
                test.FindEqualThrouDel(5, compDel);
                sw1.Stop();
                sw1Arr[i] = sw1.ElapsedTicks;
            }

            Array.Sort(sw1Arr);
            return sw1Arr[Retries / 2];
        }

        public static long Median(int Retries, int[] test)
        {
            var swArr = new long[Retries];
            for (int i = 0; i < Retries; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                test.FindEqual(5);
                sw.Stop();
                swArr[i] = sw.ElapsedTicks;
            }

            Array.Sort(swArr);
            return swArr[Retries / 2];
        }

        public static bool Equal(int item1, int item2)
        {
            return item1 == item2;
        }
    }
}

