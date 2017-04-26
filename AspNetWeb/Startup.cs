using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetWeb.Startup))]
namespace AspNetWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
