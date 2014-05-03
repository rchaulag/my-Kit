using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobBoard.Startup))]
namespace JobBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
