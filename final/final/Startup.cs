using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(final.Startup))]
namespace final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
