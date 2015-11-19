namespace BullsAndCows.Api.Models.TemplateModels
{
    using BullsAndCows.Api.Infrastructure.Mappings;
using BullsAndCows.Models;
using System;
using System.Linq;

    public class NotificationResponseModel : IMapFrom<Notification>
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public NotificationType Type { get; set; }

        public State State { get; set; }

        public int GameId { get; set; }
    }
}