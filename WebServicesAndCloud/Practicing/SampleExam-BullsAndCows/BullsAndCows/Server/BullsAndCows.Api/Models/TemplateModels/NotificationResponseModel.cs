namespace BullsAndCows.Api.Models.TemplateModels
{
    using AutoMapper;
    using BullsAndCows.Api.Infrastructure.Mappings;
    using BullsAndCows.Models;
    using System;
    using System.Linq;

    public class NotificationResponseModel : IMapFrom<Notification>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<State, String>()
                .ProjectUsing(x => x.ToString());

            config.CreateMap<NotificationType, String>()
                .ProjectUsing(x => x.ToString());

            config.CreateMap<Notification, NotificationResponseModel>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Type))
                .ForMember(x => x.State, opt => opt.MapFrom(x => x.State));
                
        }
    }
}