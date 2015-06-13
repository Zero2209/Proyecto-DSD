using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HuariqueRest.Startup))]
namespace HuariqueRest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
