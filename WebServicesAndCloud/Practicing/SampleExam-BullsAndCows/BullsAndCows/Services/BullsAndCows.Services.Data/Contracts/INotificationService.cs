namespace BullsAndCows.Services.Data.Contracts
{
    using BullsAndCows.Models;
using System;
using System.Linq;

    public interface INotificationService
    {
        IQueryable<Notification> All(string userId, int page = 1, int pageSize = 10);
    }
}
