using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektniZadatak.Startup))]
namespace ProjektniZadatak
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
