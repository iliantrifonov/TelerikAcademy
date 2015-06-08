namespace _13.CreateXls
{
    using System;
    using System.Linq;
    using System.Xml.Xsl;

    /// <summary>
    /// 13. Create an XSL stylesheet, which transforms the file catalog.xml into HTML document, formatted for viewing in a standard Web-browser.
    /// 
    /// 14.Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../catalogue.xslt");
            xslt.Transform("../../../01.CreateXmlRepresentingCatalogue/catalogue.xml", "../../catalogue.html");
        }
    }
}
