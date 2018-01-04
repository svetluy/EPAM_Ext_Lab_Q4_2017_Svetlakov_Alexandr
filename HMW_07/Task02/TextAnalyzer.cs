namespace Task02
{
    using System.Collections.Generic;

    public class TextAnalyzer
    {
        private readonly char[] separators = { ' ', '.' };
        private string text;
        private string[] words;

        public string Text
        {
            get => this.text;
            set
            {
                this.text = value;
                this.words = this.text.Split(this.separators);
            }
        }

        public Dictionary<string, int> CountSameWords(string inputText)
        {
            this.Text = inputText;
            Dictionary<string, int> numberOfWords = new Dictionary<string, int>();
            if (this.words != null)
            {
                foreach (var word in this.words)
                {
                    if (word != string.Empty)
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
            }

            return numberOfWords;
        }
    }
}
