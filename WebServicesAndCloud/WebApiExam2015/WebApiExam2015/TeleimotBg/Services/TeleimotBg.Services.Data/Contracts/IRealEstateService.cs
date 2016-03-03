namespace TeleimotBg.Services.Data.Contracts
{
    using System.Linq;

    using TeleimotBg.GlobalConstants;
    using TeleimotBg.Models;

    public interface IRealEstateService
    {
        IQueryable<RealEstate> All(int skip = UtilityConstants.DefaultSkipSize, int take = UtilityConstants.DefaultTakeSize);

        IQueryable<RealEstate> GetEstateById(int id);

        int Add(string title, string description, string address, string contact, int year, string sellPrice, string rentPrice, int type);
    }
}
