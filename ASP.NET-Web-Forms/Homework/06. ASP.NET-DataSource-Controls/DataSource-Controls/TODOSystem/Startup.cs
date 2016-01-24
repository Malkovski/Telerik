using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TODOSystem.Startup))]
namespace TODOSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
