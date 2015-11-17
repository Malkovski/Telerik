namespace WebApiExam.Models
{
    using System;
    using System.Linq;

    public class Like
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
