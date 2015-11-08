namespace WebApiExam.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WebApiExam.Models;

    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Replace model with real one!!!!!!!
        public IDbSet<Model1> Commits { get; set; }

        // Replace model with real one!!!!!!!
        public IDbSet<Model2> SoftwareProjects { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}