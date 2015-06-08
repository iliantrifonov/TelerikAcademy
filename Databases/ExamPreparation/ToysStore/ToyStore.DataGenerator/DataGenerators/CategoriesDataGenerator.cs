namespace ToyStore.DataGenerator.DataGenerators
{
    using ToyStore.Model;

    public class CategoriesDataGenerator : DataGenerator
    {
        public CategoriesDataGenerator(ToyStoreDbContext context, int count)
            : base(context, count)
        {
        }

        protected override void AddData()
        {
            for (int i = 0; i < this.Count; i++)
            {
                var category = new Category()
                {
                    Name = this.RandomGenerator.GetRandomStringWithRandomLength(2, 30)
                };

                this.DatabaseContext.Categories.Add(category);

                if (i % 200 == 0)
                {
                    this.DatabaseContext.SaveChanges();
                    this.Logger.Write(" . ");
                }
            }
        }
    }
}
