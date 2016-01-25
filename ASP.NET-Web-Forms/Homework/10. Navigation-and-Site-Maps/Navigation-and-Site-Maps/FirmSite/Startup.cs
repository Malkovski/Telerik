using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirmSite.Startup))]
namespace FirmSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
