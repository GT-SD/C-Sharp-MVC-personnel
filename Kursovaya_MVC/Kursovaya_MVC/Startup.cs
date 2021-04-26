using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kursovaya_MVC.Startup))]
namespace Kursovaya_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
