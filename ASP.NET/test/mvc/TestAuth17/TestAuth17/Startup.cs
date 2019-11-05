using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestAuth17.Startup))]
namespace TestAuth17
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
