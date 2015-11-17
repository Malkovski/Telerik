namespace SimpleForum.Models
{
    using System;
    using System.Linq;

    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
