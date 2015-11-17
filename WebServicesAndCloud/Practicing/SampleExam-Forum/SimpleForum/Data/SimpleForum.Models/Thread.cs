namespace SimpleForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Thread
    {
        private ICollection<Post> posts;
        private ICollection<Category> categories;

        public Thread()
        {
            this.posts = new HashSet<Post>();
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}
