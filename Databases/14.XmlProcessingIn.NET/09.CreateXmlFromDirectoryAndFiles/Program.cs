namespace _09.CreateXmlFromDirectoryAndFiles
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Write a program to traverse given directory and write to a 
    /// XML file its contents together with all subdirectories and 
    /// files. Use tags <file> and <dir> with appropriate attributes. 
    /// For the generation of the XML document use the class XmlWriter.
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
            var writer = XmlWriter.Create(outputFilePath);
            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("directories");
                FillXmlRecursively(pathToTraverse, writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void FillXmlRecursively(string directoryPath, XmlWriter writer)
        {
            var directories = Directory.EnumerateDirectories(directoryPath);

            writer.WriteStartElement("dir");
            writer.WriteAttributeString("path", directoryPath);
            foreach (var dir in directories)
            {
                FillXmlRecursively(dir, writer);
            }

            var files = Directory.EnumerateFiles(directoryPath);

            foreach (var file in files)
            {
                writer.WriteElementString("file", file);
            }

            writer.WriteEndElement();
        }
    }
}
