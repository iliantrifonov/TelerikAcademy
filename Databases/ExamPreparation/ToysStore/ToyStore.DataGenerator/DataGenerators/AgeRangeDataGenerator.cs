namespace ToyStore.DataGenerator.DataGenerators
{
    using System.Collections.Generic;

    using ToyStore.Model;

    public class AgeRangeDataGenerator : DataGenerator
    {
        public AgeRangeDataGenerator(ToyStoreDbContext context, int count)
            : base(context, count)
        {
        }

        protected override void AddData()
        {
            var startAges = new HashSet<int>();

            for (int i = 0; i < this.Count; i++)
            {
                var uniqueStartAge = this.RandomGenerator.GetRandomNumber(1, 100);

                while (startAges.Contains(uniqueStartAge))
                {
                    uniqueStartAge = this.RandomGenerator.GetRandomNumber(1, 100);
                }

                startAges.Add(uniqueStartAge);

                var ageRange = new AgeRanx()
                {
                    MinimumAge = uniqueStartAge,
                    MaximumAge = uniqueStartAge + 3
                };

                this.DatabaseContext.AgeRanges.Add(ageRange);

                if (i % 200 == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.Write(" . ");
                }
            }
        }
    }
}
