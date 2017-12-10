namespace Task04
{
    public class MyString
    {
        private char[] elements;

        public MyString(char[] ch)
        {
            this.elements = ch;
        }

        public int Length => this.elements.Length;

        public char this[int index]
        {
            get
            {
                return this.elements[index];
            }

            set
            {
                this.elements[index] = value;
            }
        }

        public static MyString operator +(MyString myStr, MyString str)
        {
            char[] ch = new char[myStr.Length + str.Length];
            for (int i = 0; i < ch.Length; i++)
            {
                if (i < myStr.Length)
                {
                    ch[i] = myStr[i];
                }
                else
                {
                    ch[i] = str[i - str.Length];
                }
            }

            return new MyString(ch);
        }

        public bool Contains(char ch)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == ch)
                {
                    return true;
                }
            }

            return false;
        }

        public MyString Replace(char oldCh, char newCh)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == oldCh)
                {
                    this[i] = newCh;
                }
            }

            return this;
        }

        public MyString ToUpper()
        {
            char[] ch = new char[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                ch[i] = char.ToUpper(this[i]);
            }

            return new MyString(ch);
        }

        public MyString ToLower()
        {
            char[] ch = new char[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                ch[i] = char.ToLower(this[i]);
            }

            return new MyString(ch);
        }

        public MyString Substring(int startIndex, int endIndex)
        {
            char[] ch = new char[endIndex - startIndex];
            int k = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                ch[k] = this[i];
                k++;
            }

            return new MyString(ch);
        }

        public MyString Remove(int startIndex, int endIndex)
        {
            return this.Substring(0, startIndex) + this.Substring(endIndex, this.Length);
        }

        public MyString[] Split()
        {
            int numberOfSpaces = 0;
            int[] indexes = new int[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                if (char.IsWhiteSpace(this[i]))
                {
                    if (!char.IsWhiteSpace(this[i + 1]))
                    {
                        numberOfSpaces++;
                        indexes[numberOfSpaces] = i + 1;
                    }
                }
            }

            indexes[numberOfSpaces + 1] = this.Length;
            MyString[] myStringArr = new MyString[numberOfSpaces + 1];
            for (int i = 0; i < numberOfSpaces + 1; i++)
            {
                myStringArr[i] = this.Substring(indexes[i], indexes[i + 1]);
            }

            return myStringArr;
        }

        public char[] ToCharArray()
        {
            return this.elements;
        }

        public int LastIndexOf(char ch)
        {
            int index = -1;
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == ch)
                {
                    index = i;
                }
            }

            return index;
        }

        public int FirstIndexOf(char ch)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            return new string(this.elements);
        }
    }
}
