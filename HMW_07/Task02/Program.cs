using System.Collections.Generic;
using static System.Console;

namespace Task02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[] separators = { ' ', '.' };
            WriteLine("Enter text");
            string[] words = ReadLine()?.Split(separators);

            Dictionary<string, int> numberOfWords = CountWords(words);

            foreach (var variable in numberOfWords)
            {
                WriteLine($"{variable.Key}    {variable.Value}");
            }

            ReadKey();
        }

        private static Dictionary<string, int> CountWords(string[] words)
        {
            Dictionary<string, int> numberOfWords = new Dictionary<string, int>();
            if (words != null)
            {
                foreach (var word in words)
                {
                    if (!numberOfWords.ContainsKey(word.ToLower()))
                    {
                        numberOfWords.Add(word, 1);
                    }
                    else
                    {
                        numberOfWords[word]++;
                    }
                }
            }
            else
            {
            }

            return numberOfWords;
        }
    }
}
