using System;
using System.Web.Http;
using HhPlumsailApp.ErrorsHandling;
using HhPlumsailApp.Extensions;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(HhPlumsailApp.Startup))]
namespace HhPlumsailApp {
	public partial class Startup {
		public void Configuration(IAppBuilder app) {
			GlobalConfiguration.Configure(WebApiConfig.Register);
			ServicesConfig.Register(GlobalConfiguration.Configuration);

			var OAuthServerOptions = new OAuthAuthorizationServerOptions() {
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				Provider = GlobalConfiguration.Configuration.DependencyResolver.GetService<IOAuthAuthorizationServerProvider>()
			};
			app.Use<OwinExceptionHandlerMiddleware>();

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(GlobalConfiguration.Configuration);
		}
	}
}
