namespace Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using Data;
    using Model;

    public class EntryPoint
    {
        private static DatabaseContext context;

        public static void Main(string[] args)
        {
            context = new DatabaseContext();

            // context = new DatabaseContext("SQLContextExpress");
            using (context)
            {
                // context.Authors.All(x => true);
                var entryDataFilePath = "../../complex-books.xml";
                // Insert(entryDataFilePath);
            }
        }

        private static void Insert(string filePath)
        {

        }
    }
}
