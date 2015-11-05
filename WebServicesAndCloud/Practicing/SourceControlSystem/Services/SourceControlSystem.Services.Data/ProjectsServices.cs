namespace SourceControlSystem.Services.Data
{
    using System;
    using System.Linq;
    using Constants.UtilityConstants;
    using SourceControlSystem.Services.Data.Contracts;
    using SourceControlSystem.Models;
    using SourceControlSystem.Data;

    public class ProjectsServices : IProjectsServices
    {
        private readonly IRepository<SoftwareProject> projects;
        private readonly IRepository<User> users;

        public ProjectsServices(IRepository<SoftwareProject> projectRepo, IRepository<User> usersRepo)
        {
            this.projects = projectRepo;
            this.users = usersRepo;

        }

        public IQueryable<SoftwareProject> All(int page = 1, int pageSize = UtilityConstants.PageSize)
        {
            return this.projects
                .All()
                .OrderByDescending(s => s.CreatedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }


        public int Add(string name, string description, string creator, bool isPrivate = false)
        {
            User currentUser = this.users.All().FirstOrDefault(u => u.UserName == creator);

            var newProject = new SoftwareProject
            {
                Name = name,
                Description = description,
                Private = isPrivate,
                CreatedOn = DateTime.Now
            };

            newProject.Users.Add(currentUser);

            this.projects.Add(newProject);
            this.projects.SaveChanges();

            return newProject.Id;
        }
    }
}