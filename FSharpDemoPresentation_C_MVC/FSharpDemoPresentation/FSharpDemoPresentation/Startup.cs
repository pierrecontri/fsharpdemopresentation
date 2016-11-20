using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSharpDemoPresentation.Startup))]
namespace FSharpDemoPresentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
