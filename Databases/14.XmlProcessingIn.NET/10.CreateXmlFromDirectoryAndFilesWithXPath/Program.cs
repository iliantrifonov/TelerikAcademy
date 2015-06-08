namespace _10.CreateXmlFromDirectoryAndFilesWithXPath
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Write a program to traverse given directory and write to a XML file its
    /// contents together with all subdirectories and files. Use tags <file> and <dir> 
    /// with appropriate attributes using XDocument, XElement and XAttribute.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string outputFilePath = "../../directory-structure.xml";
            string pathToTraverse = "../../../";

            WriteFilesAndDirectoriesToXml(outputFilePath, pathToTraverse);
        }

        private static void WriteFilesAndDirectoriesToXml(string outputFilePath, string pathToTraverse)
        {
            var result = new XElement("directories");
            result.Add(GetChildElements(pathToTraverse));
            result.Save(outputFilePath);
        }

        private static XElement GetChildElements(string pathToTraverse)
        {
            var directories = Directory.EnumerateDirectories(pathToTraverse);
            var directoryXml = new XElement("dir");
            directoryXml.Add(new XAttribute("path", pathToTraverse));

            foreach (var path in directories)
            {
                directoryXml.Add(GetChildElements(path));
            }

            var files = Directory.EnumerateFiles(pathToTraverse);

            foreach (var file in files)
            {
                var fileXml = new XElement("file");
                fileXml.Value = file;
                directoryXml.Add(fileXml);
            }

            return directoryXml;
        }
    }
}
