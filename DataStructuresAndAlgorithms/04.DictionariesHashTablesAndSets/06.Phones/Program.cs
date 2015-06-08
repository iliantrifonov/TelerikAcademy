namespace _06.Phones
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// A text file phones.txt holds information about people, their town and phone number:
    /// Duplicates can occur in people names, towns and phone numbers. Write a program to read 
    /// the phones file and execute a sequence of commands given in the file commands.txt:
    /// find(name) – display all matching records by given name (first, middle, last or nickname)
    /// find(name, town) – display all matching records by given name and town
    /// </summary>
    public class Program
    {
        private static MultiDictionary<string, Dictionary<string, string>> phoneBookParts;
        public static void Main(string[] args)
        {
            phoneBookParts = new MultiDictionary<string, Dictionary<string, string>>(true);
            StreamReader reader = new StreamReader(@"..\..\text.txt", Encoding.GetEncoding("windows-1251"));
            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] phonebookItems = line.Split('|');
                    for (int i = 0; i < phonebookItems.Length; i++)
                    {
                        phonebookItems[i] = phonebookItems[i].Trim(' ', ' ');
                    }

                    phoneBookParts.Add(phonebookItems[0], new Dictionary<string, string>() { { phonebookItems[1], phonebookItems[2] } });

                    line = reader.ReadLine();
                }
            }

            string name = "Mimi";

            FindAndPrint(name);

            string town = "Sofia";

            Console.WriteLine("-----------------------");
            FindAndPrint(name, town);
        }

        /// <summary>
        /// Display on the console all matching records by given name
        /// </summary>
        /// <param name="name">First, middle, last or nickname</param>
        public static void FindAndPrint(string name)
        {
            foreach (var entry in phoneBookParts)
            {
                if (entry.Key.Contains(name))
                {
                    var currentEntry = phoneBookParts[entry.Key];
                    foreach (var firstKeyValues in currentEntry)
                    {
                        foreach (var item in firstKeyValues)
                        {
                            Console.WriteLine("Found: {0}, from: {1}, phone: {2}", entry.Key, item.Key, item.Value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Display on the console all matching records by given name and town
        /// </summary>
        /// <param name="name">First, middle, last or nickname</param>
        /// <param name="town">The name of the town</param>
        public static void FindAndPrint(string name, string town)
        {
            foreach (var entry in phoneBookParts)
            {
                if (entry.Key.Contains(name))
                {
                    var currentEntry = phoneBookParts[entry.Key];
                    foreach (var firstKeyValues in currentEntry)
                    {
                        foreach (var item in firstKeyValues)
                        {
                            if (item.Key == town)
                            {
                                Console.WriteLine("Found: {0}, from: {1}, tel.: {2}", entry.Key, item.Key, item.Value);
                            }
                        }
                    }
                }
            }
        }
    }
}
