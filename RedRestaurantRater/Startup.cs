using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedRestaurantRater.Startup))]
namespace RedRestaurantRater
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
