namespace DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataGenerator.DataGenerators;

    public class EntryPoint
    {
        public static void Main()
        {
            var generators = new List<IDataGenerator>();

            foreach (var generator in generators)
            {
                generator.Generate();
            }
        }
    }
}
