namespace WebApiExam.Api
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using WebApiExam.GlobalConstants;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(AssembliesNames.WebApi));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

         //If enable corrs makes problems!!!!

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            this.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
