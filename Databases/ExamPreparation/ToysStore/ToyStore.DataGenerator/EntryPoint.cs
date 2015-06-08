namespace ToyStore.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToyStore.DataGenerator.DataGenerators;
    using ToyStore.Model;

    public class EntryPoint
    {
        public static void Main()
        {
            var context = new ToyStoreDbContext();
            var generators = new List<IDataGenerator>();
            generators.Add(new ManufacturerDataGenerator(context, 50));
            generators.Add(new CategoriesDataGenerator(context, 100));
            generators.Add(new AgeRangeDataGenerator(context, 100));
            generators.Add(new ToyDataGenerator(context, 20000));

            foreach (var generator in generators)
            {
                generator.Generate();
                context.SaveChanges();
            }
        }
    }
}
