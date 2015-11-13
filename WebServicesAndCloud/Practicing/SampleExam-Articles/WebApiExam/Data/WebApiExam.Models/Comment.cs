namespace WebApiExam.Models
{
    using System;
    using System.Linq;

    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }

        public int AtricleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
