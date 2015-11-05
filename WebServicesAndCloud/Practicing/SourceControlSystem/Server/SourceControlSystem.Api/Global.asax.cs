namespace SourceControlSystem.Api
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Http;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load("SourceControlSystem.Api"));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
