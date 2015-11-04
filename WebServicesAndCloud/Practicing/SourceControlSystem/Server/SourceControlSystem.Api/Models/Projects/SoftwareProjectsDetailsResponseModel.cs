namespace SourceControlSystem.Api.Models.Projects
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using SourceControlSystem.Models;

    public class SoftwareProjectsDetailsResponseModel
    {
        public static Expression<Func<SoftwareProject, SoftwareProjectsDetailsResponseModel>> FromModel
        {
            get
            {
                return pr => new SoftwareProjectsDetailsResponseModel
                {
                    Id = pr.Id,
                    Name = pr.Name,
                    CreatedOn = pr.CreatedOn,
                    TotalUsers = pr.Users.Count()
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TotalUsers { get; set; }
    }
}