namespace _01.CreateDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CardAccount
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string CardPin { get; set; }

        [Column(TypeName = "money")]
        public decimal CardCash { get; set; }
    }
}
