namespace BullsAndCows.Server.Wcf
{
    using BullsAndCows.Server.Wcf.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode= InstanceContextMode.PerCall)]
    public class Users : BaseService, IUsers
    {
        public IEnumerable<ListedUserMember> GetAll(string page)
        {
            var p = int.Parse(page);

            return this.Users
                .All()
                .OrderBy(x => x.Email)
               .Skip(p * 10)
               .Take(10)
               .Select(x => new ListedUserMember
               {
                   Id = x.Id,
                   Userame = x.Email
               })
               .ToList();
        }

        public DetailedUserModel GetById(string id)
        {
            return this.Users
                .All().Where(x => x.Id == id)
                .Select(x => new DetailedUserModel
                {
                    Id = id,
                    Losses = x.Losses,
                    Rank = x.Rank,
                    Username = x.UserName,
                    Wins = x.Wins
                })
                .FirstOrDefault();
        }
    }
}
