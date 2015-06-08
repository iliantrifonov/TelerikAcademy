namespace Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public Tag()
        {
            this.Articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
