using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wanderlust04.Startup))]
namespace Wanderlust04
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
