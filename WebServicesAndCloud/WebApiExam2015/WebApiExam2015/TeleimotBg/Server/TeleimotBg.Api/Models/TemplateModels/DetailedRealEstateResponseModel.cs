namespace TeleimotBg.Api.Models.TemplateModels
{
    using AutoMapper;
    using System;
    using System.Linq;
    using TeleimotBg.Api.Infrastructure.Mappings;
    using TeleimotBg.Models;

    public class DetailedRealEstateResponseModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public DateTime CreatedOn { get; set; }

        public int ConstructionYear { get; set; }

        public string Address { get; set; }

        public string RealEstateType { get; set; }

        public string Description { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }

        public int SellingPrice { get; set; }

        public int RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<RealEstate, DetailedRealEstateResponseModel>()
                    .ForMember(x => x.RealEstateType, opt => opt.MapFrom(x => x.Type.ToString()));
        }
    }
}