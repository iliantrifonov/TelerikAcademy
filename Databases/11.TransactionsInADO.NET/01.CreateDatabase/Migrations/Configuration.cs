namespace _01.CreateDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<AtmContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AtmContext context)
        {
            if (context.CardAccounts.Count() > 0)
            {
                return;
            }

            context.CardAccounts.Add(new CardAccount() { CardNumber = "0000011111", CardPin = "1234", CardCash = 250.55m });
            context.CardAccounts.Add(new CardAccount() { CardNumber = "0000011112", CardPin = "1234", CardCash = 150.55m });
            context.CardAccounts.Add(new CardAccount() { CardNumber = "0000011113", CardPin = "1234", CardCash = 200m });
            context.CardAccounts.Add(new CardAccount() { CardNumber = "0000011114", CardPin = "1234", CardCash = 500m });
            context.CardAccounts.Add(new CardAccount() { CardNumber = "0000011115", CardPin = "1234", CardCash = 1000m });
        }
    }
}
