using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Naot_Limudim_Manage.Startup))]
namespace Naot_Limudim_Manage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
