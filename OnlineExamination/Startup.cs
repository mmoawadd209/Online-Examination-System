using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineExamination.Startup))]
namespace OnlineExamination
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
