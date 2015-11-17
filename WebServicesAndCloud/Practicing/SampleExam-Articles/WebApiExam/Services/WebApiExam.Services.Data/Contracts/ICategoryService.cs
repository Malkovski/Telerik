namespace WebApiExam.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApiExam.GlobalConstants;
    using WebApiExam.Models;

    public interface ICategoryService
    {
        IQueryable<Category> All();

        IQueryable<Category> GetById(int id);

        int Add(string name);
    }
}
