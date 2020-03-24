using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(itext.Startup))]
namespace itext
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
