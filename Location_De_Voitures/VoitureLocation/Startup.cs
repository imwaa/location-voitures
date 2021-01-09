using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VoitureLocation.Startup))]
namespace VoitureLocation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
