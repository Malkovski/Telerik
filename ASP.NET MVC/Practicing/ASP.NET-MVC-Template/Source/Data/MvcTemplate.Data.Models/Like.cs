namespace MvcTemplate.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Like : BaseModel<int>
    {
        public LikeType Type { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int JokeId { get; set; }

        public virtual Joke Joke { get; set; }
    }
}
