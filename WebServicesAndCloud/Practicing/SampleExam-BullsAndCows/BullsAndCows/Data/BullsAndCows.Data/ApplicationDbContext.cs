namespace BullsAndCows.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using BullsAndCows.Models;

    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Replace model with real one!!!!!!!
        public IDbSet<Game> Games { get; set; }

        // Replace model with real one!!!!!!!
        public IDbSet<Guess> Guesses { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}