namespace SimpleForum.Models
{
    using System;
    using System.Linq;

    public class Post
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public int Rating { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
