using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntityRelations.Startup))]
namespace EntityRelations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
