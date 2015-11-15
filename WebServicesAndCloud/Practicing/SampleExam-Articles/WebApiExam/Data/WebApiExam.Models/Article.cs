namespace WebApiExam.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Article
    {
        private ICollection<Comment> comments;
        private ICollection<Tag> tags;
        private ICollection<Like> likes;

        public Article()
        {
            this.comments = new List<Comment>();
            this.tags = new List<Tag>();
            this.likes = new List<Like>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

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

        public ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
    }
}
