using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleInformationSite.Startup))]
namespace SimpleInformationSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
