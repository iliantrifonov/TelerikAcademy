namespace _07.CreateXmlFromTextFile
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// In a text file we are given the name, address and phone
    /// number of given person (each at a single line). Write a program,
    /// which creates new XML document, which contains these data in 
    /// structured XML format.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var personData = File.ReadAllLines("../../person.txt");

            var personXml = new XElement("person");
            var name = new XElement("name");
            name.Value = personData[0];
            personXml.Add(name);

            var address = new XElement("address");
            address.Value = personData[1];
            personXml.Add(address);

            var number = new XElement("phone-number");
            number.Value = personData[2];
            personXml.Add(number);

            personXml.Save("../../person.xml");
        }
    }
}
