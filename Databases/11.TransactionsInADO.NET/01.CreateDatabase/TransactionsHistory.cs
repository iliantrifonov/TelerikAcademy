namespace _01.CreateDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class TransactionsHistory
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime TransactionDate { get; set; }


        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}
