using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimuladorDeSeguros.Startup))]
namespace SimuladorDeSeguros
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
