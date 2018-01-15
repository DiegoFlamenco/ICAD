using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampDios.Startup))]
namespace CampDios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
