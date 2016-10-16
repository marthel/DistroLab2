using DistroLab2.DAL;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Diagnostics;

[assembly: OwinStartupAttribute(typeof(DistroLab2.Startup))]
namespace DistroLab2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Debug.WriteLine("KUKEN i FITTAN");

            ConfigureAuth(app);
        }
    }
}
