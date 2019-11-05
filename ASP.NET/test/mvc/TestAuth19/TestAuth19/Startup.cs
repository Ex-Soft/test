using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestAuth19.Startup))]
namespace TestAuth19
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
