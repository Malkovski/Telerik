namespace MvcTemplate.Data.Models
{
    using System.Collections.Generic;
    using Common.Models;
   
    public class Joke : BaseModel<int>
    {
        public Joke()
        {
            this.Likes = new HashSet<Like>();
        }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual JokeCategory Category { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
