using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Greenpack.Web.Startup))]
namespace Greenpack.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
