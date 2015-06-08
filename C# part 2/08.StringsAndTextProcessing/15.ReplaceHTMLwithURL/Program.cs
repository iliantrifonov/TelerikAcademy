using System;

namespace _15.ReplaceHTMLwithURL
{
    //Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:

    class Program
    {
        static void Main(string[] args)
        {
            string[] findTags = { "<a href=\"", "\">", "</a>" };
            string[] replaceTags = { "[URL=", "]", "[/URL]" };

            string htmlText = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

            for (int i = 0; i < findTags.Length; i++)
            {
                htmlText = htmlText.Replace(findTags[i], replaceTags[i]);
            }
            Console.WriteLine(htmlText);
        }
    }
}
