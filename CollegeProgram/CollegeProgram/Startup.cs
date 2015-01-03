using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollegeProgram.Startup))]
namespace CollegeProgram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
