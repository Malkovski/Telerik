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
        public IDbSet<Model1> Models1 { get; set; }

        // Replace model with real one!!!!!!!
        public IDbSet<Model2> Models2 { get; set; }

        public IDbSet<Model3> Models3 { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}