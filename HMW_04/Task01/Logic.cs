namespace Task01
{
    public class Logic
    {
        public static double AvLength(string input)
        {
            string[] words = input.Split();
            int wordsLength = 0;
            foreach (var word in words)
            {
                foreach (var ch in word)
                {
                    if (char.IsLetterOrDigit(ch))
                    {
                        wordsLength++;
                    }
                }
            }

            return (double)wordsLength / words.Length;
        }
    }
}
