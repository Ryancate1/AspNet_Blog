using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rcate_blog.Startup))]
namespace rcate_blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
