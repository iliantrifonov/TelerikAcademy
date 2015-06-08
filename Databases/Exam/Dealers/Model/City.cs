namespace Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        public City()
        {
            this.Dealers = new HashSet<Dealer>();
        }

        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Dealers { get; set; }
    }
}
