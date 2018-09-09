using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(URideApp.Startup))]
namespace URideApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
