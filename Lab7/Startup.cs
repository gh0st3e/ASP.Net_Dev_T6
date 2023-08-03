using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab7.Startup))]
namespace Lab7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
