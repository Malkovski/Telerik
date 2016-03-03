namespace TeleimotBg.Api.Models.TemplateModels
{
    using TeleimotBg.Api.Infrastructure.Mappings;
    using TeleimotBg.Models;

    public class CommonRealEstateResponseModel : IMapFrom<RealEstate>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int SellingPrice { get; set; }

        public int RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }
    }
}