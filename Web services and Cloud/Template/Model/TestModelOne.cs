﻿namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;

    public class TestModelOne
    {
        public TestModelOne()
        {
            this.CollectionTwos = new HashSet<TestModelTwo>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<TestModelTwo> CollectionTwos { get; set; }
    }
}
