using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HhPlumsailApp.Startup))]
namespace HhPlumsailApp {
	public partial class Startup {
		public void Configuration(IAppBuilder app) {
			GlobalConfiguration.Configure(WebApiConfig.Register);
			GlobalConfiguration.Configure(ServicesConfig.Register);
			ConfigureAuth(app);
		}
	}
}
