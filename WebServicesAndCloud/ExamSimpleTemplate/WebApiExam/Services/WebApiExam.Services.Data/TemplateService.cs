namespace WebApiExam.Services.Data
{
    using System;
    using System.Linq;
    using WebApiExam.Data;
    using WebApiExam.GlobalConstants;
    using WebApiExam.Models;
    using WebApiExam.Services.Data.Contracts;

    public class TemplateService : ITemplateService
    {
        private readonly IRepository<Model1> projects;
        private readonly IRepository<User> users;

        public TemplateService(IRepository<Model1> model1Repo, IRepository<User> usersRepo)
        {
            this.projects = model1Repo;
            this.users = usersRepo;
        }

        public IQueryable<Model1> All(int page = 1, int pageSize = UtilityConstants.DefaultPageSize)
        {
            return this.projects
                .All()
                //.OrderByDescending(s => s.CreatedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        // The logic here can be different ofc - parameters depends ...!!!!!!!!
        public int Add(string name, string description, string creator, bool isPrivate = false)
        {
            User currentUser = this.users.All().FirstOrDefault(u => u.UserName == creator);

            var newProject = new Model1
            {
                //Name = name,
                //Description = description,
                //Private = isPrivate,
                //CreatedOn = DateTime.Now
            };

            //newProject.Users.Add(currentUser);

            this.projects.Add(newProject);
            this.projects.SaveChanges();

            return newProject.Id;
        }
    }
}
