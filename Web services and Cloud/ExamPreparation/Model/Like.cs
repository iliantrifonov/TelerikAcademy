namespace Model
{
    public class Like
    {
        public int Id { get; set; }

        public virtual Article Article { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
