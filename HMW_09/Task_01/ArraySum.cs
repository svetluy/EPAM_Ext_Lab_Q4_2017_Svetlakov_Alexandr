namespace Task_01
{
    public static class ArraySum
    {
        public static int Sum(this int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i]; //todo pn можно и LINQ заиспользовать
            }

            return sum;
        }
    }
}
