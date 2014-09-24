using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSC440_Portal.Startup))]
namespace CSC440_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
