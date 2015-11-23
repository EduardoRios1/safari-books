using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafariBooks.Startup))]
namespace SafariBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
