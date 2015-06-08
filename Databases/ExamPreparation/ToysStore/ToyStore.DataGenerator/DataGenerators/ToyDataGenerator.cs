namespace ToyStore.DataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToyStore.Model;

    public class ToyDataGenerator : DataGenerator
    {
        public ToyDataGenerator(ToyStoreDbContext context, int count)
            : base(context, count)
        {
        }

        protected override void AddData()
        {
            var manufacturerIds = this.DatabaseContext.Manufacturers.Select(m => m.Id).ToList();
            var ageRangeIds = this.DatabaseContext.AgeRanges.Select(a => a.Id).ToList();
            var categoryIds = this.DatabaseContext.Categories.Select(c => c.Id).ToList();
            for (int i = 0; i < this.Count; i++)
            {
                var toy = new Toy()
                {
                    Name = this.RandomGenerator.GetRandomStringWithRandomLength(2, 30),
                    Type = this.RandomGenerator.GetRandomStringWithRandomLength(2, 50),
                    Price = this.RandomGenerator.GetRandomNumber(1, 500),
                    Color = this.RandomGenerator.GetRandomNumber(0, 5) == 5 ? null : this.RandomGenerator.GetRandomStringWithRandomLength(2, 20),
                };

                toy.AgeRangeId = ageRangeIds[this.RandomGenerator.GetRandomNumber(0, ageRangeIds.Count - 1)];
                toy.ManufacturerId = manufacturerIds[this.RandomGenerator.GetRandomNumber(0, manufacturerIds.Count - 1)];
                
                
                if (categoryIds.Count > 0)
                {
                    var categoryCount = this.RandomGenerator.GetRandomNumber(1, Math.Min(6, categoryIds.Count));

                    var uniqueCategoryIds = new HashSet<int>();

                    while (categoryCount > uniqueCategoryIds.Count)
                    {
                        uniqueCategoryIds.Add(this.RandomGenerator.GetRandomNumber(0, categoryIds.Count - 1));
                    }

                    foreach (var id in uniqueCategoryIds)
                    {
                        toy.Categories.Add(this.DatabaseContext.Categories.Find(id));
                    }
                }
                

                this.DatabaseContext.Toys.Add(toy);

                if (i % 200 == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.Write(" . ");
                }
            }
        }
    }
}
