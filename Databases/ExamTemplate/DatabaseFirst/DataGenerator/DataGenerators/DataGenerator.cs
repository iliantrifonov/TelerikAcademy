namespace DataGenerator.DataGenerators
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public abstract class DataGenerator : IDataGenerator
    {
        private ILogger logger;
        private DbContext context;
        private int count;
        private IRandomDataGenerator randomGenerator;

        public DataGenerator(IRandomDataGenerator randomGenerator, DbContext context, int count, ILogger logger)
        {
            this.randomGenerator = randomGenerator;
            this.context = context;
            this.count = count;
            this.logger = logger;
        }

        public DataGenerator(DbContext context, int count)
            : this(RandomDataGenerator.Instance, context, count, new ConsoleLogger())
        {
        }

        protected IRandomDataGenerator RandomGenerator
        {
            get
            {
                return this.randomGenerator;
            }
        }

        protected int Count
        {
            get
            {
                return this.count;
            }
        }

        protected DbContext DatabaseContext
        {
            get
            {
                return this.context;
            }
        }

        protected ILogger Logger
        {
            get
            {
                return this.logger;
            }
        }

        public virtual void Generate()
        {
            this.context.Configuration.AutoDetectChangesEnabled = false;

            this.logger.WriteLine();
            this.logger.WriteLine(string.Format("Generating from {0}", this.GetType().Name));

            this.AddData();

            this.logger.WriteLine(string.Format("\nFinished Generating from {0}", this.GetType().Name));

            this.context.Configuration.AutoDetectChangesEnabled = true;
        }

        protected abstract void AddData();
    }
}
