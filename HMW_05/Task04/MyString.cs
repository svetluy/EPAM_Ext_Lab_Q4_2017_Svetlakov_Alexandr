namespace Task04
{
    class MyString
    {
        char[] elements;

        public char this[int index]
        {
            get
            {
                return elements[index];
            }
            set
            {
                elements[index] = value;
            }
        }
        public int Length => elements.Length;

        MyString(char[] ch)
        {
            elements = ch;
        }

        public bool Contains(char ch)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == ch)
                    return true;
            }
            return false;
        }
        public MyString Replace(char oldCh, char newCh)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == oldCh)
                    this[i] = newCh;
            }
            return this;
        }
        public MyString ToUpper()
        {
            foreach (var ch in elements)
            {
                char.ToUpper(ch);
            }
            return new MyString(elements);
        }
        public MyString ToLower()
        {
            foreach (var ch in elements)
            {
                char.ToLower(ch);
            }
            return new MyString(elements);
        }
        public MyString Substring(int startIndex, int endIndex)
        {
            char[] ch = new char[endIndex - startIndex];
            for (int i = startIndex; i < endIndex; i++)
            {
                ch[i] = this[i];
            }
            return new MyString(ch);
        }
        public MyString Remove(int startIndex, int endIndex)
        {
            return this.Substring(0, startIndex) + this.Substring(endIndex,this.Length);
        }
        public MyString[] Split()
        {
            int numberOfSpaces=0;
            int[] indexes = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                if (char.IsWhiteSpace(this[i]))
                {
                    indexes[numberOfSpaces] = i;
                    numberOfSpaces++;
                }
            }

            MyString[] myStringArr = new MyString[numberOfSpaces+1];
            for (int i = 0; i < numberOfSpaces+1; i++)
            {
                myStringArr[i] = Substring(indexes[i],indexes[i+1]);
            }
            return myStringArr;
        }
        public char[] ToCharArray()
        {
            return elements;
        }
        public int LastIndexOf(char ch)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (this[i] == ch)
                    index = i;
            }
            return index;
        }
        public int FirstIndexOf(char ch)
        {
            for (int i = 0; i < Length; i++)
            {
                if (this[i] == ch)
                    return i;
            }
            return -1;
        }
        public static MyString operator +(MyString myStr, MyString str)
        {
            char[] ch = new char[myStr.Length+str.Length];
            for (int i = 0; i < ch.Length; i++)
            {
                if (i < myStr.Length)
                    ch[i] = myStr[i];
                else
                    ch[i] = str[i - str.Length];
            }
            return new MyString(ch);
        }

    }
}
