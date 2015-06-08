namespace Model
{
    using System;

    public class Alert
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? DateOfExpiration { get; set; }
    }
}
