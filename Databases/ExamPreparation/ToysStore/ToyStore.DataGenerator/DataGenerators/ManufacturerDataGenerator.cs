namespace ToyStore.DataGenerator.DataGenerators
{
    using System.Collections.Generic;

    using ToyStore.Model;

    public class ManufacturerDataGenerator : DataGenerator
    {
        public ManufacturerDataGenerator(ToyStoreDbContext context, int count)
            : base(context, count)
        {
        }

        protected override void AddData()
        {
            var manufacturerNames = new HashSet<string>();
            for (int i = 0; i < this.Count; i++)
            {
                var uniqueName = this.RandomGenerator.GetRandomStringWithRandomLength(3, 50);
                while (manufacturerNames.Contains(uniqueName))
                {
                    uniqueName = this.RandomGenerator.GetRandomStringWithRandomLength(3, 50);
                }

                manufacturerNames.Add(uniqueName);

                var currentManufacturer = new Manufacturer()
                {
                    Country = this.RandomGenerator.GetRandomStringWithRandomLength(3, 15),
                    Name = uniqueName,
                };

                this.DatabaseContext.Manufacturers.Add(currentManufacturer);

                if (i % 200 == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.Write(" . ");
                }
            }
        }
    }
}
