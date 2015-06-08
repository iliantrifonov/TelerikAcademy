namespace Model
{
    using System;

    public class Comment
    {
        public int Id { get; set; }

        public virtual Article Article { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public DateTime? DateCreated { get; set; }

        public string Content { get; set; }
    }
}
