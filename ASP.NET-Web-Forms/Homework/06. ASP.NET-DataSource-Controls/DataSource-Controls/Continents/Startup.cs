using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Continents.Startup))]
namespace Continents
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
