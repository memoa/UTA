using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UTA.Startup))]
namespace UTA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
