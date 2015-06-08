using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Class1
    {
        [MaxLength(50)]
        [MinLength(10)]
        [Index(IsUnique = true)]
        [Required]
        public int Id { get; set; }
    }
}
