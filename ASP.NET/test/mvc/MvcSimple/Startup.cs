using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcSimple.Startup))]
namespace MvcSimple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
