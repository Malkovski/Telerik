namespace Working_with_Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Tweet
    {
        public Tweet()
        {
            this.Tags = new List<Tag>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual List<Tag> Tags { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
