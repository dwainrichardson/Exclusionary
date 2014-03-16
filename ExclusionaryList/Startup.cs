using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExclusionaryList.Startup))]
namespace ExclusionaryList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
