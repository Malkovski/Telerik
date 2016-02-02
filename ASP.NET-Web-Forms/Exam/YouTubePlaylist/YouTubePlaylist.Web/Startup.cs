using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YouTubePlaylist.Web.Startup))]
namespace YouTubePlaylist.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
