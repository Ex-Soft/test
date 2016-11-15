using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelerikMvcAppStd.Startup))]
namespace TelerikMvcAppStd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
