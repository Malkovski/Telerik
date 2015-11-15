namespace WebApiExam.Services.Data
{
    using System;
    using System.Linq;
    using WebApiExam.Data;
    using WebApiExam.Models;
    using WebApiExam.Services.Data.Contracts;

    public class AlertService : IAlertService
    {
        private IRepository<Alert> alerts;

        public AlertService(IRepository<Alert> alertRepo)
        {
            this.alerts = alertRepo;
        }

        public IQueryable<Alert> All()
        {
            return this.alerts.All();
        }

        public IQueryable<Alert> GetById(int id)
        {
            return this.alerts.All().Where(x => x.Id == id);
        }

        public int Add(string message, int daysOfValidity)
        {
            var newAlert = new Alert
            {
                Message = message,
                CreatedOn = DateTime.Now,
                ExpireOn = DateTime.Now.AddDays(daysOfValidity)
            };

            this.alerts.Add(newAlert);
            this.alerts.SaveChanges();

            return newAlert.Id;
        }
    }
}
