using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DistroLab2.Startup))]
namespace DistroLab2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
