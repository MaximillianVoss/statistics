using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Statistics.Startup))]
namespace Statistics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
