using System;
using System.Text;
using System.Collections.Generic;

namespace FakeTextMarkupLanguage
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder(500);
            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine());
                sb.Append('\n');
            }
            Console.WriteLine(MakeFTML(sb.ToString()));
        }

        public static string MakeFTML(string a)
        {
            string[] arr = a.Split(new char[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != string.Empty && arr[i][0] == '/')
                {
                    if (arr[i] == "/upper")
                    {
                        int index = i;
                        StringBuilder sBuilder = new StringBuilder();
                        Stack<string> st = new Stack<string>();
                        while (arr[index - 1] != "upper")
                        {
                            st.Push(arr[index - 1]);
                            arr[index - 1] = string.Empty;
                            index--;
                        }
                        while (st.Count > 0)
                        {
                            sBuilder.Append(st.Pop());
                        }
                        arr[i] = string.Empty;
                        arr[index] = ToUpper(sBuilder.ToString());
                        arr[index - 1] = string.Empty;
                    }
                    else if (arr[i] == "/lower")
                    {
                        int index = i;
                        StringBuilder sBuilder = new StringBuilder();
                        Stack<string> st = new Stack<string>();
                        while (arr[index - 1] != "lower")
                        {
                            st.Push(arr[index - 1]);
                            arr[index - 1] = string.Empty;
                            index--;
                        }
                        while (st.Count > 0)
                        {
                            sBuilder.Append(st.Pop());
                        }
                        arr[i] = string.Empty;
                        arr[index] = ToLower(sBuilder.ToString());
                        arr[index - 1] = string.Empty;
                    }
                    else if (arr[i] == "/del")
                    {
                        int index = i;
                        StringBuilder sBuilder = new StringBuilder();
                        Stack<string> st = new Stack<string>();
                        while (arr[index - 1] != "del")
                        {
                            st.Push(arr[index - 1]);
                            arr[index - 1] = string.Empty;
                            index--;
                        }
                        while (st.Count > 0)
                        {
                            sBuilder.Append(st.Pop());
                        }
                        arr[i] = string.Empty;
                        arr[index] = Delete(sBuilder.ToString());
                        arr[index - 1] = string.Empty;
                    }
                    else if (arr[i] == "/toggle")
                    {
                        int index = i;
                        StringBuilder sBuilder = new StringBuilder();
                        Stack<string> st = new Stack<string>();
                        while (arr[index - 1] != "toggle")
                        {
                            st.Push(arr[index - 1]);
                            arr[index - 1] = string.Empty;
                            index--;
                        }
                        while (st.Count > 0)
                        {
                            sBuilder.Append(st.Pop());
                        }
                        arr[i] = string.Empty;
                        arr[index] = Toggle(sBuilder.ToString());
                        arr[index - 1] = string.Empty;
                    }
                    else if (arr[i] == "/rev")
                    {
                        int index = i;
                        StringBuilder sBuilder = new StringBuilder();
                        Stack<string> st = new Stack<string>();
                        while (arr[index - 1] != "rev")
                        {
                            st.Push(arr[index - 1]);
                            arr[index - 1] = string.Empty;
                            index--;
                        }
                        while (st.Count > 0)
                        {
                            sBuilder.Append(st.Pop());
                        }
                        arr[i] = string.Empty;
                        arr[index] = Reverse(sBuilder.ToString());
                        arr[index - 1] = string.Empty;
                    }
                    //i = 0;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != string.Empty)
                {
                    sb.Append(arr[i]);
                }
            }
            return sb.ToString();
        }

        public static string Delete(string a)
        {
            return string.Empty;
        }

        public static string Toggle(string a)
        {
            StringBuilder sb = new StringBuilder(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsUpper(a[i]))
                {
                    sb.Append(a[i].ToString().ToLower());
                }
                else
                {
                    sb.Append(a[i].ToString().ToUpper());
                }
            }
            return sb.ToString();
        }

        public static string ToUpper(string a)
        {
            return a.ToUpper();
        }

        public static string ToLower(string a)
        {
            return a.ToLower();
        }

        public static string Reverse(string a)
        {
            StringBuilder sb = new StringBuilder(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                sb.Append(a[a.Length - 1 - i]);
            }
            return sb.ToString();
        }
    }
}