namespace _01.ExtendStringBuilder
{
    using System;
    using System.Text;

    //1.Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.
    public static class ExtensionClass
    {
        public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
        {
            if (startIndex >= sb.Length || startIndex + length >= sb.Length)
            {
                throw new IndexOutOfRangeException();
            }
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(sb[startIndex + i].ToString());
            }
            return result;
        }
    }
}