using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoxBuster.Startup))]
namespace BoxBuster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
