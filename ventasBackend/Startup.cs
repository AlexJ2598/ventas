using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ventasBackend.Startup))]
namespace ventasBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
