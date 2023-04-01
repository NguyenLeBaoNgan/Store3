using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Store3.Startup))]
namespace Store3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
