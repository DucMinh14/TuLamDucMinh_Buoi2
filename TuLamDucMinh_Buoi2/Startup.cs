using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TuLamDucMinh_Buoi2.Startup))]
namespace TuLamDucMinh_Buoi2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
