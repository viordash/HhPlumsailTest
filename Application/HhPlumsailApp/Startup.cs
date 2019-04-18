using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HhPlumsailApp.Startup))]

namespace HhPlumsailApp {
	public partial class Startup {
		public void Configuration(IAppBuilder app) {
			ConfigureAuth(app);

			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}
