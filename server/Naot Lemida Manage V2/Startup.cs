using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Naot_Lemida_Manage_V2.Startup))]
namespace Naot_Lemida_Manage_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
