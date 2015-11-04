namespace SourceControlSystem.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using Models;
    using Constants.UtilityConstants;

    public interface IProjectsServices
    {
        IQueryable<SoftwareProject> All(int page = 1, int pageSize = UtilityConstants.PageSize);

        int Add(string name, string description, string creator, bool isPrivate = false);
    }
}
