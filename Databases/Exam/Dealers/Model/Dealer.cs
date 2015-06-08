namespace Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        public Dealer()
        {
            this.Cars = new HashSet<Car>();
            this.Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
