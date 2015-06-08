namespace _01.CreateDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using _01.CreateDatabase.Migrations;

    public partial class AtmContext : DbContext
    {
        public AtmContext()
            : base("name=AtmContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmContext, Configuration>());
        }

        public virtual DbSet<CardAccount> CardAccounts { get; set; }

        public virtual DbSet<TransactionsHistory> TransactionsHistorys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardAccount>()
                .Property(e => e.CardNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CardAccount>()
                .Property(e => e.CardPin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CardAccount>()
                .Property(e => e.CardCash)
                .HasPrecision(19, 4);
        }
    }
}
