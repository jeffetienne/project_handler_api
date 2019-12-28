using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectHandler.Startup))]
namespace ProjectHandler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
