using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IRL.Web.Startup))]
namespace IRL.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
