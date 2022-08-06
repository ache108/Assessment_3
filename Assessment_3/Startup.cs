using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assessment_3.Startup))]
namespace Assessment_3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
