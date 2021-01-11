using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EXercises.Startup))]
namespace EXercises
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
