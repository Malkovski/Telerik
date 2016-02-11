using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Working_with_Data.Web.Startup))]
namespace Working_with_Data.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
