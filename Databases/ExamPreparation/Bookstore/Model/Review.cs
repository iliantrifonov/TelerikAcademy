namespace Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public string Content { get; set; }
    }
}
