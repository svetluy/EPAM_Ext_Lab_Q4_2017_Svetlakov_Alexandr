namespace Task02
{
    public class Logic
    {
        public static string Double(string input1, string input2)
        {
            string answer = input1;
            foreach (var ch in input2)
            {
                if (input1.Contains(ch.ToString()))
                {
                    input1 = input1.Replace(ch.ToString(), string.Empty);
                    answer = answer.Replace(ch.ToString(), new string(ch, 2));
                }
            }

            return answer;
        }

        public static string Input(string message)
        {
            System.Console.WriteLine(message);
            return System.Console.ReadLine();
        }
    }
}
