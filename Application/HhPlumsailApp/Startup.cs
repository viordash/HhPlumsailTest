using System;
using System.Web.Http;
using HhPlumsailApp.Extensions;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(HhPlumsailApp.Startup))]
namespace HhPlumsailApp {
	public partial class Startup {
		public void Configuration(IAppBuilder app) {
			var config = new HttpConfiguration();
			ServicesConfig.Register(config);

			var OAuthServerOptions = new OAuthAuthorizationServerOptions() {
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				Provider = config.DependencyResolver.GetService<IOAuthAuthorizationServerProvider>()
			};

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

			WebApiConfig.Register(config);
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);
		}
	}
}
