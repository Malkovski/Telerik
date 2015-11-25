namespace TeleimotBg.Services.Data
{
    using System;
    using System.Linq;
    using System.Web;
    using TeleimotBg.Data;
    using TeleimotBg.Models;
    using TeleimotBg.Services.Data.Contracts;
    using Microsoft.AspNet.Identity;
    using TeleimotBg.GlobalConstants;

    public class RealEstateService : IRealEstateService
    {
        private readonly IRepository<RealEstate> estates;

        public RealEstateService(IRepository<RealEstate> estatesRepo)
        {
            this.estates = estatesRepo;
        }

        public IQueryable<RealEstate> All(int skip = UtilityConstants.DefaultSkipSize, int take = UtilityConstants.DefaultTakeSize)
        {
            if (take > 100)
            {
                take = 100;
            }

            if (skip < 0)
            {
                skip = 0;
            }
       
            return this.estates.All()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(skip * take)
                .Take(take);
        }


        public IQueryable<RealEstate> GetEstateById(int id)
        {
            return this.estates.All().Where(x => x.Id == id);
        }


        public int Add(string title, string description, string address, string contact, int year, string sellPrice , string rentPrice, int type)
        {
            var newEstate = new RealEstate
            {
                Title = title,
                Description= description,
                Address = address,
                Contact = contact,
                ConstructionYear = year,
                SellingPrice = sellPrice ==null ? 0 : int.Parse(sellPrice),
                RentingPrice = rentPrice == null ?  0 : int.Parse(rentPrice),
                Type = (RealEstateType)type,
                CreatedOn = DateTime.UtcNow,
                CanBeSold = sellPrice != null ? true : false,
                CanBeRented = rentPrice != null ? true :  false,
                UserId = HttpContext.Current.User.Identity.GetUserId()
            };

            this.estates.Add(newEstate);
            this.estates.SaveChanges();

            return newEstate.Id;
        }
    }
}
