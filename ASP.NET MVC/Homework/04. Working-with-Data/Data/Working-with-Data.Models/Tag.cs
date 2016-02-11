

namespace Working_with_Data.Models
{
    using System.Collections.Generic;

    public class Tag
    {
        public Tag()
        {
            this.Tweets = new List<Tweet>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public virtual List<Tweet> Tweets { get; set; }
    }
}
