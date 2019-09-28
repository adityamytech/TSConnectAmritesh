using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TS_Connect.Startup))]
namespace TS_Connect
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
