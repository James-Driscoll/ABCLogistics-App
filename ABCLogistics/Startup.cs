using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABCLogistics.Startup))]
namespace ABCLogistics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
