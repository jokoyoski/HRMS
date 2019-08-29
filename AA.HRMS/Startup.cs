using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AA.HRMS.Startup))]
namespace AA.HRMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
