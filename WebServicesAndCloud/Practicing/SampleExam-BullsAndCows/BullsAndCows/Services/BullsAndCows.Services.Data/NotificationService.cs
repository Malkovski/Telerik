namespace BullsAndCows.Services.Data
{
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Data.Contracts;
    using System;
    using System.Linq;

    public class NotificationService : INotificationService
    {
        private readonly IRepository<Notification> notifications;

        public NotificationService(IRepository<Notification> notifies)
        {
            this.notifications = notifies;
        }

        public IQueryable<Notification> All(string userId, int page = 1, int pageSize = 10)
        {
           return this.notifications.All()
              .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
