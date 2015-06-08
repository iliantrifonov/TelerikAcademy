namespace _7.XmlToHtml
{
    using System;
    using System.Linq;
    using System.Xml.Xsl;

    public class Program
    {
        public static void Main(string[] args)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../students.xslt");
            xslt.Transform("../../students.xml", "../../students.html");
        }
    }
}
