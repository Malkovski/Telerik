namespace SourceControlSystem.Api.Infrastucture.Mappings
{
    using System;
    using System.Linq;
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
        
    }
}
