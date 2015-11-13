namespace WebApiExam.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Article
    {
        private ICollection<Comment> comments;
        private ICollection<Tag> tags;

        public Article()
        {
            this.comments = new List<Comment>();
            this.tags = new List<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Category { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
