namespace Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [MinLength(13)]
        [MaxLength(13)]
        public string Isbn { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public decimal? Price { get; set; }

        public string WebSite { get; set; }

        [MinLength(2)]
        [Required]
        public string Title { get; set; }
    }
}
