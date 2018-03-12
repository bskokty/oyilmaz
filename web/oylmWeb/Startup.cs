using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(oylmWeb.Startup))]
namespace oylmWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
