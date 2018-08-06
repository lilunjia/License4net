using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication_LisenceFileTest.Startup))]
namespace WebApplication_LisenceFileTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
           
        }
    }
}
