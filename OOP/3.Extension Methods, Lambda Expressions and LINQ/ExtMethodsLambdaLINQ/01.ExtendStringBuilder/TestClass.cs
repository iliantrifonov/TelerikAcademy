namespace _01.ExtendStringBuilder
{
    using System;
    using System.Text;

    public class TestClass
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("abcdefg");
            StringBuilder substring = sb.Substring(1, 2);
            Console.WriteLine(substring);
        }
    }
}