namespace TeleimotBg.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using TeleimotBg.GlobalConstants;

    public class RealEstate
    {
        private ICollection<Comment> comments;

        public RealEstate()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinTitleLen)]
        [MaxLength(ValidationConstants.MaxTitleLen)]
        public string Title { get; set; }

        [Range(ValidationConstants.PriceMinValue, ValidationConstants.PriceMaxValue)]
        public int SellingPrice { get; set; }

        [Range(ValidationConstants.PriceMinValue, ValidationConstants.PriceMaxValue)]
        public int RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public DateTime CreatedOn { get; set; }

        [Range(ValidationConstants.MinAllowedYear, ValidationConstants.MaxAllowedYear)]
        public int ConstructionYear { get; set; }

        [Required]
        public string Address { get; set; }

        public RealEstateType Type { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinDescriprionLen)]
        [MaxLength(ValidationConstants.MaxDescriptionLen)]
        public string Description { get; set; }

        [Required]
        public string Contact { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments 
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
