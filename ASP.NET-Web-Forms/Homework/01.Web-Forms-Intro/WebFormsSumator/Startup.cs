using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsSumator.Startup))]
namespace WebFormsSumator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
