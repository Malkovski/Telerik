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
           var lastTenUserNotifies = this.notifications.All()
              .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

           foreach (var item in lastTenUserNotifies)
           {
               item.State = State.Read;
           }

           this.notifications.SaveChanges();

           return lastTenUserNotifies;
        }

        public IQueryable<Notification> Next(string userId)
        {
            var unread = this.notifications
                .All()
                .Where(x => x.UserId == userId)
                .Where(x => x.State == State.Unread)
                .OrderBy(x => x.DateCreated);

            if (unread.Count() != 0)
            {
                unread.FirstOrDefault().State = State.Read;
                this.notifications.SaveChanges();
            }

            return unread;
        }
    }
}
