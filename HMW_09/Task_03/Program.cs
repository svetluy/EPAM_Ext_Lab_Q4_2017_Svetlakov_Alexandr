namespace Task_03
{
    using System;
    using static FindMethods;
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            const int Retries = 1000;
            const int N = 1000;
            int[] test = new int[N];
            var rand = new Random();
            for (int i = 0; i < N; i++)
            {
                test[i] = rand.Next(10);
            }

            WriteLine($"Find elapsed(median) {Median(Retries, test)}ticks\n" +
                      $"Find with delegate elapsed(median) {MedianDel(Retries, test)}ticks\n" +
                      $"Find with anonymus func elapsed(median) {MedianAnonDel(Retries, test)}ticks\n" +
                      $"Find with lambda elapsed(median) {MedianLambaDel(Retries, test)}ticks\n" +
                      $"Find with linq elapsed(median) {MedianLinq(Retries, test)}ticks");

            ReadKey();
        }
    }
}
