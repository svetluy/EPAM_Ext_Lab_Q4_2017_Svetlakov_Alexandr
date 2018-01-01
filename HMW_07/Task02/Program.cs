namespace Task02
{
    using System.Collections.Generic;
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            TextAnalyzer textAnalyzer = new TextAnalyzer();
            WriteLine("Enter text");
            Dictionary<string, int> words = textAnalyzer.CountSameWords(ReadLine());

            foreach (var word in words)
            {
                WriteLine($"The word \"{word.Key}\" in the text occurs {word.Value} times");
            }

            ReadKey();
        }
    }
}
