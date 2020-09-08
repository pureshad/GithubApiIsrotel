using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GithubApiIsrotel.Startup))]
namespace GithubApiIsrotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
