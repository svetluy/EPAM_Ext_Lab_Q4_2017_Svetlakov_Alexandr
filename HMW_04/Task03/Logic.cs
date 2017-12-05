namespace Task03
{
    using System.Diagnostics;
    using System.Text;

    public class Logic
    {
        public static long ElapsedTime(int n)
        {
            var sw = new Stopwatch();
            sw.Start();
            Add(n, "*");
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long ElapsedTimeSb(int n)
        {
            var sw = new Stopwatch();
            sw.Start();
            AddSb(n, "*");
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private static void AddSb(int n, string symbol)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(symbol);
            }
        }

        private static void Add(int n, string symbol)
        {
            string str = string.Empty;

            for (int i = 0; i < n; i++)
            {
                str += symbol;
            }
        }
    }
}
