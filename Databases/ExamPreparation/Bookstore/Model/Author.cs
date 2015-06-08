namespace Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
