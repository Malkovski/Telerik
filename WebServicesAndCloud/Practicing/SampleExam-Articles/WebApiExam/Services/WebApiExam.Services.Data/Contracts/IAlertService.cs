namespace WebApiExam.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using WebApiExam.Models;

    public interface IAlertService
    {
        IQueryable<Alert> All();

        IQueryable<Alert> GetById(int id);

        int Add(string message, int daysOfValidity);
    }
}
