namespace TeleimotBg.Api.Models.TemplateModels
{
    using TeleimotBg.Api.Infrastructure.Mappings;
    using TeleimotBg.Models;

    public class CustomUserResponseModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public int RealEstates { get; set; }

        public int Comments { get; set; }

        public float Rating { get; set; }
    }
}