using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(opensource_manager.Startup))]
namespace opensource_manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
