using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeGeist2019.Startup))]
namespace CodeGeist2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
