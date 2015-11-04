namespace SourceControlSystem.Api
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
