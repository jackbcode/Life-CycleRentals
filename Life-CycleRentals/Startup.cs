using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Life_CycleRentals.Startup))]
namespace Life_CycleRentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
