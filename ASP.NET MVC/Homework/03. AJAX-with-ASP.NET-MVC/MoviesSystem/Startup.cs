using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesSystem.Startup))]
namespace MoviesSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
