﻿namespace Model
{
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public virtual Dealer Dealer { get; set; }

        [Required]
        public int DealerId { get; set; }
    }
}
