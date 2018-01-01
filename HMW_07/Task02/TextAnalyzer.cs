using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class TextAnalyzer
    {
        private string text;
        private char[] separators = { ' ', '.' };
        private string[] words;

        public string Text
        {
            get => text;
            set
            {
                text = value;
                words = text.Split(separators);
            }
        }

        public Dictionary<string, int> CountSameWords(string text)
        {
            Text = text;
            Dictionary<string, int> numberOfWords = new Dictionary<string, int>();
            if (words != null)
            {
                foreach (var word in words)
                {
                    string keyWord = word.ToLower();
                    if (!numberOfWords.ContainsKey(keyWord))
                    {
                        numberOfWords.Add(keyWord, 1);
                    }
                    else
                    {
                        numberOfWords[keyWord]++;
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
