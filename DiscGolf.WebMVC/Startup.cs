using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiscGolf.WebMVC.Startup))]
namespace DiscGolf.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
