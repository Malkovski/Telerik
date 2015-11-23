namespace TeleimotBg.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
using TeleimotBg.GlobalConstants;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinCommentLen)]
        [MaxLength(ValidationConstants.MaxCommentLen)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }

    }
}
