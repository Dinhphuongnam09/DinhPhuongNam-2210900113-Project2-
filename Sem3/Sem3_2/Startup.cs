using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sem3_2.Startup))]
namespace Sem3_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
