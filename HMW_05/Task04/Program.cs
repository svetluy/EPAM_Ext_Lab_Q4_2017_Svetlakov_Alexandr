namespace Task04
{
    using static System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Enter string");
            MyString str = new MyString(ReadLine().ToCharArray());
            WriteLine("ToUpper");
            WriteLine(str.ToUpper());

            WriteLine("ToLower");
            WriteLine(str.ToLower());

            WriteLine(@"Contains 'a'");
            WriteLine(str.Contains('a'));

            WriteLine(@"First index of 'a'");
            WriteLine(str.FirstIndexOf('a'));

            WriteLine(@"Last index of 'a'");
            WriteLine(str.LastIndexOf('a'));

            WriteLine("substring(3,6)");
            WriteLine(str.Substring(3, 6));

            WriteLine(@"replace('a','b')");
            WriteLine(str.Replace('a', 'b'));

            MyString[] split = new MyString[10];

            WriteLine("split");
            split = str.Split();
            for (int i = 0; i < split.Length; i++)
            {
                WriteLine(split[i]);
            }

            ReadKey();
        }
    }
}
