namespace TeleimotBg.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TeleimotBg.Models;

    public class TeleimotDbContext : IdentityDbContext<User>, ITeleimotDbContext
    {
        public TeleimotDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Replace model with real one!!!!!!!
        public IDbSet<RealEstate> RealEstates { get; set; }

        // Replace model with real one!!!!!!!
        public IDbSet<Comment> Comments { get; set; }

        public static TeleimotDbContext Create()
        {
            return new TeleimotDbContext();
        }
    }
}