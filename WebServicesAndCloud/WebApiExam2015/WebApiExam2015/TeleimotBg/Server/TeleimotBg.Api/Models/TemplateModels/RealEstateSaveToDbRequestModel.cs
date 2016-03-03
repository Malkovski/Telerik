namespace TeleimotBg.Api.Models.TemplateModels
{
    using System.ComponentModel.DataAnnotations;

    using TeleimotBg.Api.Infrastructure.Mappings;
    using TeleimotBg.GlobalConstants;
    using TeleimotBg.Models;

    public class RealEstateSaveToDbRequestModel : IMapFrom<RealEstate>
    {
        [Required]
        [MinLength(ValidationConstants.MinTitleLen)]
        [MaxLength(ValidationConstants.MaxTitleLen)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinDescriprionLen)]
        [MaxLength(ValidationConstants.MaxDescriptionLen)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Range(ValidationConstants.MinAllowedYear, ValidationConstants.MaxAllowedYear)]
        public int ConstructionYear { get; set; }

        public string SellingPrice { get; set; }

        public string RentingPrice { get; set; }

        [Range(0, 3)]
        public int Type { get; set; }
    }
}