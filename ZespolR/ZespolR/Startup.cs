using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZespolR.Startup))]
namespace ZespolR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
