using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01.GenerateRandomNumberHtmlControls.Startup))]
namespace _01.GenerateRandomNumberHtmlControls
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
